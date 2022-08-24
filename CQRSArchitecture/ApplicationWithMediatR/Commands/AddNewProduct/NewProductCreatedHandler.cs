namespace ApplicationWithMediatR.Commands.AddNewProduct
{
    using ApplicationWithMediatR.Events;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    public class NewProductCreatedHandler : INotificationHandler<ProductCreated>
    {
        private readonly ILogger<NewProductCreatedHandler> _logger;

        public NewProductCreatedHandler(ILogger<NewProductCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Product {notification.NewProduct.Id} was added to data base.");
            return Task.CompletedTask;
        }
    }
}
