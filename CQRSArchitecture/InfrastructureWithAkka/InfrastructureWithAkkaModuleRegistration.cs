namespace InfrastructureWithAkka
{
    using ApplicationWithAkka.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class InfrastructureWithAkkaModuleRegistration
    {
        public static void AddInfrastructureWithAkkaModule(this IServiceCollection services)
        {
            services.AddHostedService<ActorSystemProvider>();
            services.AddTransient<ICommandProcessor, CommandProcessor>();
        }
    }
}
