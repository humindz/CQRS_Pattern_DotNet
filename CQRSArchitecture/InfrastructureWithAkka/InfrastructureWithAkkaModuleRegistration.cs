namespace InfrastructureWithAkka
{
    using ApplicationWithAkka.Commands.AddNewProduct;
    using ApplicationWithAkka.Interfaces;
    using ApplicationWithAkka.Queries;
    using InfrastructureWithAkka.CommandHandlerActors;
    using InfrastructureWithAkka.CQRS;
    using InfrastructureWithAkka.QueryHandlerActors;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfrastructureWithAkkaModuleRegistration
    {
        public static void AddInfrastructureWithAkkaModule(this IServiceCollection services)
        {
            services.AddSingleton<IActorSystemProvider, ActorSystemProvider>();
            services.AddSingleton<IAkkaCommandProcessor, CommandProcessor>();
            services.AddSingleton<IAkkaQueryProcessor, QueryProcessor>();

            // Command handlers
            services.AddSingleton<IAkkaCommandHandler<AddNewProductCommand>, AddNewProductCommandHandlerActor>();

            // Query handlers
            services.AddSingleton<IAkkaQueryHandler<GetProductsByNameQuery>, GetProductsByNameQueryHandlerActor>();
        }
    }
}
