using Akka.Actor;
using ApplicationWithAkka.Interfaces;
using ApplicationWithAkka.Queries;
using InfrastructureWithAkka.QueryHandlerActors;
using System;
using System.Collections.Concurrent;
using InfrastructureWithAkka.Extensions;

namespace InfrastructureWithAkka.CQRS
{
    public class QueryProcessorActor : ReceiveActor
    {
        private readonly IActorSystemProvider actorSystemProvider;
        private readonly IApplicationWithAkkaContext context;

        private readonly ConcurrentDictionary<Type, IActorRef> processDirectory =
            new ConcurrentDictionary<Type, IActorRef>();

        public QueryProcessorActor(IActorSystemProvider actorSystemProvider, IApplicationWithAkkaContext context, IAkkaQueryProcessor akkaQueryProcessor)
        {
            this.actorSystemProvider = actorSystemProvider;
            this.context = context;

            InitializeReceiverActors(akkaQueryProcessor);

            Receive<IAkkaQuery>(ForwardCommand);
        }

        private void InitializeReceiverActors(IAkkaQueryProcessor akkaQueryProcessor)
        {
            processDirectory.TryAdd(typeof(GetProductsByNameQuery),
                this.actorSystemProvider.InitializeActor(
                    () => new GetProductsByNameQueryHandlerActor(this.context),
                    nameof(GetProductsByNameQueryHandlerActor)));

            processDirectory.TryAdd(typeof(GetProductByPriceRangeQuery),
                this.actorSystemProvider.InitializeActor(
                    () => new GetProductByPriceRangeQueryHandlerActor(this.context, akkaQueryProcessor),
                    nameof(GetProductByPriceRangeQueryHandlerActor)));
        }

        private void ForwardCommand(IAkkaQuery query)
        {
            this.processDirectory.TryGetValue(query.GetType(), out var actorRef);
            actorRef?.Forward(query);
        }
    }
}
