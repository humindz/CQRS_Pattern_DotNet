using Akka.Actor;

namespace InfrastructureWithAkka.CQRS
{
    public class ActorSystemProvider : IActorSystemProvider
    {
        public ActorSystem CqrsActorSystem { get; }

        public ActorSystemProvider()
        {
            this.CqrsActorSystem = ActorSystem.Create("CQRS");
        }
    }
}
