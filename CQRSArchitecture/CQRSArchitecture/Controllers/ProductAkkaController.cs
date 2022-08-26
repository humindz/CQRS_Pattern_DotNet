using Microsoft.AspNetCore.Mvc;
using ApplicationWithAkka.Services.ProductService;
using ApplicationWithAkka.ViewModels;
using System.Threading.Tasks;

namespace CQRSArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAkkaController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductAkkaController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var result = await this.productService.GetProductsByName(name);
            return result != null ? Ok(result) : (IActionResult)NotFound();
        }

        [HttpGet("price-range")]
        public async Task<NoContentResult> GetProductsByUnitPriceRange(decimal minPrice, decimal maxPrice)
        {
            this.productService.SendGetProductsByPriceRangeQuery(minPrice, maxPrice);
            return await Task.FromResult(NoContent());
        }

        [HttpPost]
        public Task<NoContentResult> AddNewProduct(ProductAkkaViewModel product)
        {
            this.productService.AddNewProduct(product);
            return Task.FromResult(NoContent());
        }
    }
}
