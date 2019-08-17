using DotaApp.Common;
using DotaApp.Data.Common;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DotaApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UsernamePasswordDto usernamePasswordDto)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var user = this.userService.Authenticate(usernamePasswordDto);

            if (user == null)
            {
                return BadRequest(new { message = Constants.IncorrectUsernamePassword });
            }

            return Ok(user);
        }

        [AllowAnonymous]
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
    }
}