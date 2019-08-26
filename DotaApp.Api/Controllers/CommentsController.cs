﻿using DotaApp.Data.Common;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Comments;
using Microsoft.AspNetCore.Mvc;

namespace DotaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddCommentDto addComment)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            try
            {
                this.commentService.AddComment(addComment);

                return Ok();
            }
            catch (DotaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}