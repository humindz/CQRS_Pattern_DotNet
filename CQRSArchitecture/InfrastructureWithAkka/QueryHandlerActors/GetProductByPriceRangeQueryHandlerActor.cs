using Akka.Actor;
using ApplicationWithAkka.Interfaces;
using ApplicationWithAkka.Queries;
using System.Linq;
using ApplicationWithAkka.ViewModels;

namespace InfrastructureWithAkka.QueryHandlerActors
{
    public class GetProductByPriceRangeQueryHandlerActor : ReceiveActor, IAkkaQueryHandler<GetProductByPriceRangeQuery>
    {
        private readonly IApplicationWithAkkaContext context;
        private readonly IActorRef queryResultSender;

        public GetProductByPriceRangeQueryHandlerActor(IApplicationWithAkkaContext context, IAkkaQueryProcessor akkaQueryProcessor)
        {
            this.context = context;
            this.queryResultSender = akkaQueryProcessor.QueryResultSender;
            Receive<GetProductByPriceRangeQuery>(ExecuteQuery);
        }

        public void ExecuteQuery(GetProductByPriceRangeQuery query)
        {
            var products = context.Products.Where(p => p.UnitPrice >= query.MinPrice && p.UnitPrice <= query.MaxPrice);
            queryResultSender.Tell(products.Select(product => new ProductAkkaViewModel
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
