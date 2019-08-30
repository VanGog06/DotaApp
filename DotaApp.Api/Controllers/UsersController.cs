using DotaApp.Common;
using DotaApp.Data.Common;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotaApp.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UsernamePasswordDto usernamePasswordDto)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            try
            {
                var user = this.userService.Authenticate(usernamePasswordDto);

                return Ok(user);
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            try
            {
                var user = this.userService.Register(userDto);

                return Ok(user);
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("update/{id}")]
        [Authorize]
        public IActionResult Update([FromBody] UpdateUserDto profile)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            try
            {
                this.userService.Update(profile);

                return Ok();
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}