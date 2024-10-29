using Microsoft.AspNetCore.Mvc;
using NaturalisBackend.Services;

namespace NaturalisBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _productService.GetProducts();
            return Ok(items);
        }
    }
}
