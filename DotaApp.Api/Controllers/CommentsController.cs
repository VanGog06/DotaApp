﻿using DotaApp.Data.Common;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Comments;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("items/{itemId}")]
        public IActionResult All([FromRoute] int itemId)
        {
            var comments = this.commentService.All(itemId);

            return Ok(comments);
        }

        [HttpPost("add")]
        [Authorize(Roles = "User")]
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