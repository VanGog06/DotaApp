using DotaApp.Services.DataServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DotaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : Controller
    {
        private readonly IHeroService heroService;

        public HeroesController(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var heroes = this.heroService.GetAll();

            return Ok(heroes);
        }
    }
}