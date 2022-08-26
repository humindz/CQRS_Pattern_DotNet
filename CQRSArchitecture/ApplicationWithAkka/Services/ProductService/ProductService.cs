using ApplicationWithAkka.Commands.AddNewProduct;
using ApplicationWithAkka.Interfaces;
using ApplicationWithAkka.Queries;
using ApplicationWithAkka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationWithAkka.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IAkkaCommandProcessor commandProcessor;
        private readonly IAkkaQueryProcessor queryProcessor;

        public ProductService(IAkkaCommandProcessor commandProcessor, IAkkaQueryProcessor queryProcessor)
        {
            this.commandProcessor = commandProcessor;
            this.queryProcessor = queryProcessor;
        }

        public async Task<IList<ProductAkkaViewModel>> GetProductsByName(string name)
        {
            var result = await queryProcessor.ProcessQuery(new GetProductsByNameQuery { Name = name });
            return result?.Count > 0 ? result.Select(product => (ProductAkkaViewModel)product).ToList() : null;
        }

        public void SendGetProductsByPriceRangeQuery(decimal minPrice, decimal maxPrice)
        {
            queryProcessor.ForwardQuery(new GetProductByPriceRangeQuery { MinPrice = minPrice, MaxPrice = maxPrice});
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
