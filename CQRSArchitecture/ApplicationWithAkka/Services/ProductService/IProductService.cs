using ApplicationWithAkka.ViewModels;

namespace ApplicationWithAkka.Services.ProductService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        void AddNewProduct(ProductAkkaViewModel product);

        Task<IList<ProductAkkaViewModel>> GetProductsByName(string name);
    }
}
