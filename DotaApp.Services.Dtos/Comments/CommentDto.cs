using System;
using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Comments
{
    public class CommentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Comment { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
