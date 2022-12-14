namespace ApplicationWithMediatR.Commands.AddNewProduct
{
    using ApplicationWithMediatR.Events;
    using ApplicationWithMediatR.Interfaces;
    using Domain;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, int>
    {
        private readonly IApplicationWithMediatRContext context;
        private readonly IMediator mediator;

        public AddNewProductCommandHandler(IApplicationWithMediatRContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<int> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
            //add new product
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                UnitPrice = 0,
                CurrentStock = 0
            };
            context.Products.Add(product);

            await mediator.Publish(new ProductCreated(product), cancellationToken);

            await Task.Run(() => { }, cancellationToken);

            return 1;
        }
    }
}
