namespace ApplicationWithAkka.Commands.AddNewProduct
{
    using ApplicationWithAkka.Interfaces;
    using Domain;

    public class AddNewProductCommandHandler : ICommandHandler<AddNewProductCommand>
    {
        public void ExecuteCommand(AddNewProductCommand command)
        {
            //add new product
            var product = new Product
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                UnitPrice = command.UnitPrice,
                CurrentStock = command.CurrentStock
            };
        }
    }
}
