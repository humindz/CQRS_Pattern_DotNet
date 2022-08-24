namespace InfrastructureWithAkka
{
    using Akka.Actor;

    public interface IActorSystemProvider
    {
        /// <summary>
        /// Get the actor system singleton
        /// </summary>
        ActorSystem ActorSystem { get; }
    }
}
