using Akka.Actor;
using ApplicationWithAkka.Interfaces;

namespace InfrastructureWithAkka.CQRS
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class QueryProcessor : IAkkaQueryProcessor
    {
        private readonly IActorRef queryProcessorActor;

        public QueryProcessor(IActorSystemProvider actorSystemProvider, IApplicationWithAkkaContext context)
        {
            var queryProcessorActorProps = Props.Create(() => new QueryProcessorActor(actorSystemProvider, context));
            queryProcessorActor = actorSystemProvider
                .CqrsActorSystem
                .ActorOf(queryProcessorActorProps, nameof(QueryProcessorActor));
        }

        public async Task<List<IResult>> ProcessQuery(IAkkaQuery query)
        {
            return (List<IResult>) await queryProcessorActor.Ask(query);
        }
    }
}
