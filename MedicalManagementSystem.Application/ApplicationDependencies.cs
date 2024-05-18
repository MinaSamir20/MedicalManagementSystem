using FluentValidation;
using MediatR;
using MedicalManagementSystem.Application.Behaviers;
using MedicalManagementSystem.Application.Services.Auth;
using MedicalManagementSystem.Application.Services.Cache;
using MedicalManagementSystem.Application.Services.Departments;
using MedicalManagementSystem.Application.Services.Doctors;
using MedicalManagementSystem.Application.Services.Patients;
using MedicalManagementSystem.Application.Services.Specialities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MedicalManagementSystem.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ISpecialitiesService, SpecialitiesService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
