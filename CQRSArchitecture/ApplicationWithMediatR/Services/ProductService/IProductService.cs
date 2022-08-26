using ApplicationWithMediatR.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationWithMediatR.Services.ProductService
{
    public interface IProductService
    {
        Task<IList<ProductMediatRViewModel>> GetProductsByName(string name);

        Task<int> AddNewProduct(ProductMediatRViewModel product);
    }
}
