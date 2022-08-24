using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.ViewModels;
using Application.Commands.AddNewProduct;
using Application.Queries.GetProductByName;

namespace Application.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IQueryDispatcher queryDispatcher;

        public ProductService(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
            this.queryDispatcher = queryDispatcher;
        }

        public IList<ProductViewModel> GetProductsByName(string name)
        {
            var result = queryDispatcher.Send(new GetProductsByNameQuery { Name = name });
            return result?.Count > 0 ? result.Cast<ProductViewModel>().ToList() : null;
        }

        public void AddNewProduct(ProductViewModel product)
        {
            commandDispatcher.Send(
                new AddNewProductCommand
                {
                    Name = product.Name,
                    Description = product.Description,
                    UnitPrice = product.UnitPrice,
                    CurrentStock = product.CurrentStock
                }
            );
        }
    }
}
