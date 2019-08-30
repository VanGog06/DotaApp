using DotaApp.Data.Common;
using DotaApp.Services.DataServices.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            try
            {
                var hero = this.heroService.GetById(id);

                return Ok(hero);
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}