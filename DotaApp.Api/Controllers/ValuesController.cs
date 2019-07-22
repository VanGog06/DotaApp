using System.Collections.Generic;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService userService;

        public ValuesController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
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
                return BadRequest(new { message = "Password is incorrect" });
            }

            return Ok(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
