using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.ViewModels;

namespace Application.Queries.GetProductByName
{
    public class GetProductsByNameQueryHandler : IQueryHandler<GetProductsByNameQuery>
    {
        private readonly IApplicationContext context;

        public GetProductsByNameQueryHandler(IApplicationContext context)
        {
            this.context = context;
        }

        public IList<IResult> Handle(GetProductsByNameQuery query)
        {
            var products = context.Products.Where(p => p.Name.Contains(query.Name, StringComparison.OrdinalIgnoreCase)).ToList();

            return products.Select(product => new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    UnitPrice = product.UnitPrice,
                    CurrentStock = product.CurrentStock,
                    IsOutOfStock = product.IsOutOfStock
                })
                .Cast<IResult>()
                .ToList();
        }
    }
}
