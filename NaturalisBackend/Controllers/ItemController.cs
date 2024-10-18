using Microsoft.AspNetCore.Mvc;
using NaturalisBackend.Services;

namespace NaturalisBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly TestService _itemService;

        public ItemController(TestService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _itemService.GetAllItems();
            return Ok(items);
        }
    }
}
