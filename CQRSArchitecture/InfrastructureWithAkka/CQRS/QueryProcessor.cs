using System.Collections.Generic;
using System.Threading.Tasks;
using Akka.Actor;
using ApplicationWithAkka.Interfaces;
using InfrastructureWithAkka.Extensions;
using InfrastructureWithAkka.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace InfrastructureWithAkka.CQRS
{
    public class QueryProcessor : IAkkaQueryProcessor
    {
        private readonly IActorRef queryProcessorActor;

        public QueryProcessor(IActorSystemProvider actorSystemProvider, IApplicationWithAkkaContext context, IHubContext<ResultHub> hub)
        {
            var queryProcessorActorProps =
                Props.Create(() => new QueryProcessorActor(actorSystemProvider, context, this));
            queryProcessorActor = actorSystemProvider
                .CqrsActorSystem
                .ActorOf(queryProcessorActorProps, nameof(QueryProcessorActor));

            this.QueryResultSender = actorSystemProvider.InitializeActor(
                () => new QueryResultSenderActor(hub), nameof(QueryResultSenderActor));
        }

        public async Task<List<IResult>> ProcessQuery(IAkkaQuery query)
        {
            return (List<IResult>) await queryProcessorActor.Ask(query);
        }

        public void ForwardQuery(IAkkaQuery query)
        {
            queryProcessorActor.Tell(query);
        }

        public IActorRef QueryResultSender { get; }
    }
}
