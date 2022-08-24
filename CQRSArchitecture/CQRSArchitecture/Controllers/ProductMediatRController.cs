using Microsoft.AspNetCore.Mvc;

namespace CQRSArchitecture.Controllers
{
    using ApplicationWithAkka.Services.ProductService;
    using ApplicationWithAkka.ViewModels;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductAkkaController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductAkkaController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public Task<NoContentResult> AddNewProduct(ProductAkkaViewModel product)
        {
            this.productService.AddNewProduct(product);
            return Task.FromResult(NoContent()); ;
        }
    }
}
