using System;
using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Comments
{
    public class CommentsReviewDto
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

        [Required]
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }
    }
}
