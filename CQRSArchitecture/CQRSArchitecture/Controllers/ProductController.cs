using Microsoft.AspNetCore.Mvc;
using Application.Services.ProductService;
using Application.ViewModels;

namespace CQRSArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{name}")]
        public IActionResult GetProductsByName(string name)
        {
            var result = this.productService.GetProductsByName(name);
            return result != null ? Ok(result) : (IActionResult)NotFound();
        }

        [HttpPost]
        public IActionResult AddNewProduct(ProductViewModel product)
        {
            this.productService.AddNewProduct(product);
            return NoContent(); ;
        }
    }
}
