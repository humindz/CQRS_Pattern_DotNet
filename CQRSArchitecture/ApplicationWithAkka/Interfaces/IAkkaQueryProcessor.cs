using Akka.Actor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationWithAkka.Interfaces
{
    public interface IAkkaQueryProcessor
    {
        Task<List<IResult>> ProcessQuery(IAkkaQuery query);

        void ForwardQuery(IAkkaQuery query);

        IActorRef QueryResultSender { get; }
    }
}
