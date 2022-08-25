using Application.Interfaces;
using ApplicationWithMediatR.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    using ApplicationWithAkka.Interfaces;

    public static class InfrastructureModuleRegistration
    {
        public static void AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationContext, ApplicationContext>();
            services.AddSingleton<IApplicationWithMediatRContext, ApplicationWithMediatRContext>();
            services.AddSingleton<IApplicationWithAkkaContext, ApplicationWithAkkaContext>();
        }
    }
}
