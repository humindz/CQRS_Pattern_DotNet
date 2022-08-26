using Akka.Actor;
using ApplicationWithAkka.Interfaces;
using ApplicationWithAkka.Queries;
using ApplicationWithAkka.ViewModels;
using System;
using System.Linq;

namespace InfrastructureWithAkka.QueryHandlerActors
{
    public class GetProductsByNameQueryHandlerActor : ReceiveActor, IAkkaQueryHandler<GetProductsByNameQuery>
    {
        private readonly IApplicationWithAkkaContext context;

        public GetProductsByNameQueryHandlerActor(IApplicationWithAkkaContext context)
        {
            this.context = context;
            Receive<GetProductsByNameQuery>(ExecuteQuery);
        }

        public void ExecuteQuery(GetProductsByNameQuery query)
        {
            var products = context.Products.Where(p => p.Name.Contains(query.Name, StringComparison.OrdinalIgnoreCase)).ToList();

            Sender.Tell(products.Select(product => new ProductAkkaViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    UnitPrice = product.UnitPrice,
                    CurrentStock = product.CurrentStock,
                    IsOutOfStock = product.IsOutOfStock
                })
                .Cast<IResult>()
                .ToList());
        }
    }
}
