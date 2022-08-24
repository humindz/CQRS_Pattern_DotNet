using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CommandsMediatR = ApplicationWithMediatR.Commands;
using QueriesMediatR = ApplicationWithMediatR.Queries;

namespace ApplicationWithMediatR
{
    using ApplicationWithMediatR.Services.ProductService;

    public static class ApplicationWithMediatRModuleRegistration
    {
        public static void AddApplicationWithMediatRModule(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CommandsMediatR.AddNewProduct.AddNewProductCommand),
                typeof(QueriesMediatR.GetProductsByName.GetProductsByNameQuery));

            services.AddScoped<IProductService, ProductService>();
        }
    }
}
