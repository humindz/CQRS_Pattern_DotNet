using Akka.Actor;
using ApplicationWithAkka.Commands.AddNewProduct;
using ApplicationWithAkka.Interfaces;
using InfrastructureWithAkka.CommandHandlerActors;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace InfrastructureWithAkka.CQRS
{
    public class CommandProcessorActor : ReceiveActor
    {
        private readonly IActorSystemProvider actorSystemProvider;
        private readonly IApplicationWithAkkaContext context;

        private readonly ConcurrentDictionary<Type, IActorRef> processDirectory =
            new ConcurrentDictionary<Type, IActorRef>();

        public CommandProcessorActor(IActorSystemProvider actorSystemProvider, IApplicationWithAkkaContext context)
        {
            this.actorSystemProvider = actorSystemProvider;
            this.context = context;

            InitializeReceiverActors();

            Receive<IAkkaCommand>(ForwardCommand);
        }

        private void InitializeReceiverActors()
        {
            processDirectory.TryAdd(typeof(AddNewProductCommand),
                InitializeActor(() => new AddNewProductCommandHandlerActor(this.context),
                    nameof(AddNewProductCommandHandlerActor)));
        }

        private IActorRef InitializeActor<TActor>(Expression<Func<TActor>> factory, string actorName) where TActor: ActorBase
        {
            var commandProcessorActorProps = Props.Create(factory);
            return actorSystemProvider
                .CqrsActorSystem
                .ActorOf(commandProcessorActorProps, actorName);
        }

        private void ForwardCommand(IAkkaCommand command)
        {
            this.processDirectory.TryGetValue(command.GetType(), out var actorRef);
            actorRef?.Forward(command);
        }
    }
}
