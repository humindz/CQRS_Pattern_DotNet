using Akka.Actor;
using ApplicationWithAkka.Commands.AddNewProduct;
using ApplicationWithAkka.Interfaces;
using Domain;
using ApplicationWithAkka.Events;
using InfrastructureWithAkka.CQRS;

namespace InfrastructureWithAkka.CommandHandlerActors
{
    public class AddNewProductCommandHandlerActor : ReceiveActor, IAkkaCommandHandler<AddNewProductCommand>
    {
        private readonly IActorSystemProvider actorSystemProvider;
        private readonly IApplicationWithAkkaContext context;

        public AddNewProductCommandHandlerActor(IApplicationWithAkkaContext context, IActorSystemProvider actorSystemProvider)
        {
            this.context = context;
            this.actorSystemProvider = actorSystemProvider;
            Receive<AddNewProductCommand>(ExecuteCommand);
        }

        public void ExecuteCommand(AddNewProductCommand command)
        {
            var product = new Product
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                UnitPrice = command.UnitPrice,
                CurrentStock = command.CurrentStock
            };
            context.Products.Add(product);

            actorSystemProvider.CqrsActorSystem.EventStream.Publish(new CommandSucceededEvent
            {
                Command = command
            });
        }
    }
}
