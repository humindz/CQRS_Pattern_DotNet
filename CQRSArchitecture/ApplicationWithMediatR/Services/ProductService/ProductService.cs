namespace ApplicationWithMediatR.Services.ProductService
{
    using ApplicationWithMediatR.Commands.AddNewProduct;
    using ApplicationWithMediatR.Queries.GetProductsByName;
    using ApplicationWithMediatR.ViewModels;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IMediator mediator;

        public ProductService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IList<ProductMediatRViewModel>> GetProductsByName(string name)
        {
            var result = await mediator.Send(new GetProductsByNameQuery { Name = name });
            return result?.Count > 0 ? result.ToList() : null;
        }

        public async Task<int> AddNewProduct(ProductMediatRViewModel product)
        {
            return await this.mediator.Send(
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
