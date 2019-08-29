using DotaApp.Data.Common;
using DotaApp.Services.DataServices.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotaApp.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpDelete("comments/delete/{id}")]
        public IActionResult DeleteCommentById([FromRoute]int id)
        {
            try
            {
                this.adminService.DeleteCommentById(id);

                return Ok();
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("review")]
        public IActionResult Review()
        {
            try
            {
                var comments = this.adminService.Review();

                return Ok(comments);
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("approve/{id}")]
        public IActionResult Approve([FromRoute]int id)
        {
            try
            {
                this.adminService.Approve(id);
                var comments = this.adminService.Review();

                return Ok(comments);
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("reject/{id}")]
        public IActionResult Reject([FromRoute]int id)
        {
            try
            {
                this.adminService.Reject(id);
                var comments = this.adminService.Review();

                return Ok(comments);
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}