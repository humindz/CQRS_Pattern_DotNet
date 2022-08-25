using Akka.Actor;
using ApplicationWithAkka.Commands.AddNewProduct;
using ApplicationWithAkka.Interfaces;
using Domain;

namespace InfrastructureWithAkka.CommandHandlerActors
{
    public class AddNewProductCommandHandlerActor : ReceiveActor, IAkkaCommandHandler<AddNewProductCommand>
    {
        private readonly IApplicationWithAkkaContext context;

        public AddNewProductCommandHandlerActor(IApplicationWithAkkaContext context)
        {
            this.context = context;
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
        }
    }
}
