using Application.Commands;
using Application.Interfaces;
using Application.Queries;
using Application.Services.ProductService;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    using Application.Commands.AddNewProduct;
    using Application.Queries.GetProductByName;

    public static class ApplicationModuleRegistration
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            // Command Handlers
            services.AddScoped<ICommandHandler<AddNewProductCommand>, AddNewProductCommandHandler>();

            // Query Handlers
            services.AddScoped<IQueryHandler<GetProductsByNameQuery>, GetProductsByNameQueryHandler>();

            // Services
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
