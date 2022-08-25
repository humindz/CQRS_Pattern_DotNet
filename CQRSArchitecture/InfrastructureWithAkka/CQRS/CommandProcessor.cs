using Akka.Actor;
using ApplicationWithAkka.Interfaces;

namespace InfrastructureWithAkka.CQRS
{
    public class CommandProcessor : IAkkaCommandProcessor
    {
        private readonly IActorRef commandProcessorActor;

        public CommandProcessor(IActorSystemProvider actorSystemProvider, IApplicationWithAkkaContext context)
        {
            var commandProcessorActorProps = Props.Create(() => new CommandProcessorActor(actorSystemProvider, context));
            commandProcessorActor = actorSystemProvider
                .CqrsActorSystem
                .ActorOf(commandProcessorActorProps, nameof(CommandProcessorActor));
        }

        public void ProcessCommand(IAkkaCommand command)
        {
            commandProcessorActor.Tell(command);
        }
    }
}
