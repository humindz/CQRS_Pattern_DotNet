using System.Collections.Generic;
using Application.ViewModels;

namespace Application.Services.ProductService
{
    public interface IProductService
    {
        IList<ProductViewModel> GetProductsByName(string name);
        void AddNewProduct(ProductViewModel product);
    }
}
