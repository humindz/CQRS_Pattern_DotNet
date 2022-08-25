using ApplicationWithAkka.Commands.AddNewProduct;
using ApplicationWithAkka.Interfaces;
using ApplicationWithAkka.Services.ProductService;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationWithAkka
{
    public static class ApplicationWithAkkaModuleRegistration
    {
        public static void AddApplicationWithAkkaModule(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
