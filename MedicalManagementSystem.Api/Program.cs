using MedicalManagementSystem.Api.Middleware;
using MedicalManagementSystem.Application;
using MedicalManagementSystem.Application.Helper;
using MedicalManagementSystem.Domain.Entities.Identity;
using MedicalManagementSystem.Infrastructure;
using MedicalManagementSystem.Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Maping JWT Class With JWT in appsettings.json
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

// Add services to the container.

builder.Services.AddControllers();

#region Identity
builder.Services.AddIdentity<User, IdentityRole>(o =>
{
    o.Password.RequiredLength = 8;
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireNonAlphanumeric = false;

    o.SignIn.RequireConfirmedAccount = false;
    o.SignIn.RequireConfirmedPhoneNumber = false;
    o.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<AppDbContext>();
#endregion

#region Swagger Authorize configuration
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "’MissionSystemApi", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

});
#endregion

#region ConnectionString
builder.Services.AddDbContext<AppDbContext>(op =>
        op.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
#endregion

builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis")!);
    return ConnectionMultiplexer.Connect(configuration);
});

#region JWT Bearer Authorization
// add authentication services 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
        ClockSkew = TimeSpan.Zero
    };
});
#endregion

#region Localization

builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt => opt.ResourcesPath = "");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCulitures =
    [
        new CultureInfo("en-US"),
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR"),
        new CultureInfo("ar-EG"),
    ];

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCulitures;
    options.SupportedUICultures = supportedCulitures;
});

#endregion

builder.Services.AddInfrastructureDependencies().AddApplicationDependencies();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Cors
var Cors = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(Cors,
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
#endregion

#region Files
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
#endregion

#region Ignore Null Value
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
#endregion

var app = builder.Build();

#region Seeding AdminUser and Roles
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Doctor", "User" };
    //Create 
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            IdentityRole roleRole = new(role);
            await roleManager.CreateAsync(roleRole);
        }
    }
    // Create Admin
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    string email = "minasamir9749@gmail.com";
    string password = "AdmIn%2024%";
    if (await userManager.FindByNameAsync(email) == null)
    {
        User user = new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "Admin",
            NormalizedUserName = "Admin",
            ImageUrl = "admin.jpg",
            Email = email,
            NormalizedEmail = email,
            SecurityStamp = string.Empty
        };
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}
#endregion

#region Localization Middelware
var opt = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(opt!.Value);
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

//Use Cors
app.UseCors(Cors);

// Use Static Files to get file from Server Files
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @$"{Files.masterFolderName}")),
    RequestPath = new PathString($"/{Files.masterFolderName}")
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();