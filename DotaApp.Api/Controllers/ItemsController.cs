using DotaApp.Services.DataServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DotaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var items = this.itemService.GetAll();

            return Ok(items);
        }
    }
}