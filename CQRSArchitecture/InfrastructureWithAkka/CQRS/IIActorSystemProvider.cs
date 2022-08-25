using Akka.Actor;

namespace InfrastructureWithAkka.CQRS
{
    public interface IActorSystemProvider
    {
        /// <summary>
        /// Get the actor system singleton
        /// </summary>
        ActorSystem CqrsActorSystem { get; }
    }
}
