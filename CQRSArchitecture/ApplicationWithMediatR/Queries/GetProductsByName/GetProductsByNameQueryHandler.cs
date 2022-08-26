using ApplicationWithMediatR.Interfaces;
using ApplicationWithMediatR.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationWithMediatR.Queries.GetProductsByName
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, List<ProductMediatRViewModel>>
    {
        private readonly IApplicationWithMediatRContext context;

        public GetProductsByNameQueryHandler(IApplicationWithMediatRContext context)
        {
            this.context = context;
        }

        public async Task<List<ProductMediatRViewModel>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {

            var products =  context.Products.Where(p => p.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase)).ToList();

            return products.Select(p => new ProductMediatRViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    UnitPrice = p.UnitPrice,
                    IsOutOfStock = p.IsOutOfStock
                })
                .ToList();
        }
    }
}
