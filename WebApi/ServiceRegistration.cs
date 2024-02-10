using System.Reflection;
using DataAccess.EFCore.Repositories;
using DataAccess.EFCore.UnitOfWork;
using Domain.Interfaces;

namespace WebApi
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services) {
      
            var assembly = typeof(ServiceRegistration).Assembly;

            var serviceTypes = assembly.GetTypes()
                .Where(type => type.IsClass &&
                               !type.IsAbstract &&
                               type.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IService))));

            // Register all found services
            foreach (var serviceType in serviceTypes) {
                var interfaceType = serviceType.GetInterfaces().FirstOrDefault(i => i.IsAssignableFrom(typeof(IService)));
                if (interfaceType != null) {
                    services.AddTransient(interfaceType, serviceType);
                }
            }

            return services;
        }
    }
}
