using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationWithMediatR.Services.ProductService;
using ApplicationWithMediatR.ViewModels;

namespace CQRSArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMediatRController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductMediatRController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var result = await this.productService.GetProductsByName(name);
            return result != null ? Ok(result) : (IActionResult)NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductMediatRViewModel product)
        {
            await this.productService.AddNewProduct(product);
            return NoContent(); ;
        }
    }
}
