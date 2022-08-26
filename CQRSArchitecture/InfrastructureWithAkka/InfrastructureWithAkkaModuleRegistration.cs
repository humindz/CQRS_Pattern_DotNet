using ApplicationWithAkka.Commands.AddNewProduct;
using ApplicationWithAkka.Interfaces;
using ApplicationWithAkka.Queries;
using InfrastructureWithAkka.CommandHandlerActors;
using InfrastructureWithAkka.CQRS;
using InfrastructureWithAkka.EventHub;
using InfrastructureWithAkka.QueryHandlerActors;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureWithAkka
{
    public static class InfrastructureWithAkkaModuleRegistration
    {
        public static void AddInfrastructureWithAkkaModule(this IServiceCollection services)
        {
            services.AddSingleton<IActorSystemProvider, ActorSystemProvider>();
            services.AddSingleton<IAkkaCommandProcessor, CommandProcessor>();
            services.AddSingleton<IAkkaQueryProcessor, QueryProcessor>();
            services.AddSingleton<IEventHub, EventHub.EventHub>();

            // Command handlers
            services.AddSingleton<IAkkaCommandHandler<AddNewProductCommand>, AddNewProductCommandHandlerActor>();

            // Query handlers
            services.AddSingleton<IAkkaQueryHandler<GetProductsByNameQuery>, GetProductsByNameQueryHandlerActor>();
            services.AddSingleton<IAkkaQueryHandler<GetProductByPriceRangeQuery>, GetProductByPriceRangeQueryHandlerActor>();
        }
    }
}
