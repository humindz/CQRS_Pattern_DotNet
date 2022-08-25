using Akka.Actor;
using ApplicationWithAkka.Interfaces;
using ApplicationWithAkka.Queries;
using InfrastructureWithAkka.QueryHandlerActors;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace InfrastructureWithAkka.CQRS
{
    public class QueryProcessorActor : ReceiveActor
    {
        private readonly IActorSystemProvider actorSystemProvider;
        private readonly IApplicationWithAkkaContext context;

        private readonly ConcurrentDictionary<Type, IActorRef> processDirectory =
            new ConcurrentDictionary<Type, IActorRef>();

        public QueryProcessorActor(IActorSystemProvider actorSystemProvider, IApplicationWithAkkaContext context)
        {
            this.actorSystemProvider = actorSystemProvider;
            this.context = context;

            InitializeReceiverActors();

            Receive<IAkkaQuery>(ForwardCommand);
        }

        private void InitializeReceiverActors()
        {
            processDirectory.TryAdd(typeof(GetProductsByNameQuery),
                InitializeActor(() => new GetProductsByNameQueryHandlerActor(this.context),
                    nameof(GetProductsByNameQueryHandlerActor)));
        }

        private IActorRef InitializeActor<TActor>(Expression<Func<TActor>> factory, string actorName) where TActor: ActorBase
        {
            var queryProcessorActorProps = Props.Create(factory);
            return actorSystemProvider
                .CqrsActorSystem
                .ActorOf(queryProcessorActorProps, actorName);
        }

        private void ForwardCommand(IAkkaQuery query)
        {
            this.processDirectory.TryGetValue(query.GetType(), out var actorRef);
            actorRef?.Forward(query);
        }
    }
}
