namespace ApplicationWithAkka.Services.ProductService
{
    using ApplicationWithAkka.Commands.AddNewProduct;
    using ApplicationWithAkka.Interfaces;
    using ApplicationWithAkka.ViewModels;
    using System;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly ICommandProcessor commandProcessor;

        public ProductService(ICommandProcessor commandProcessor)
        {
            this.commandProcessor = commandProcessor;
        }

        public void AddNewProduct(ProductAkkaViewModel product)
        {
            this.commandProcessor.ProcessCommand(
                new AddNewProductCommand
                {
                    Id = Guid.NewGuid(),
                    Name = product.Name,
                    Description = product.Description,
                    UnitPrice = product.UnitPrice,
                    CurrentStock = product.CurrentStock
                }
            );
        }
    }
}
