using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationWithAkka.ViewModels;

namespace ApplicationWithAkka.Services.ProductService
{
    public interface IProductService
    {
        void AddNewProduct(ProductAkkaViewModel product);

        Task<IList<ProductAkkaViewModel>> GetProductsByName(string name);

        void SendGetProductsByPriceRangeQuery(decimal minPrice, decimal maxPrice);
    }
}
