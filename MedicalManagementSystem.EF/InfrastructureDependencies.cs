using MedicalManagementSystem.Infrasturcture.Repositories.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalManagementSystem.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
