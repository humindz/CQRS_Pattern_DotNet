namespace InfrastructureWithAkka
{
    using Akka.Actor;
    using ApplicationWithAkka.Interfaces;

    public class CommandProcessor : ICommandProcessor
    {
        private readonly IActorRef commandProcessorActor;

        public CommandProcessor(IActorSystemProvider actorSystemProvider)
        {
            var commandProcessorActorProps = Props.Create(() => new CommandProcessorActor());
            commandProcessorActor = actorSystemProvider
                .ActorSystem
                .ActorOf(commandProcessorActorProps, nameof(CommandProcessorActor));
        }

        public void ProcessCommand(ICommand command)
        {
            commandProcessorActor.Tell(command);
        }
    }
}
