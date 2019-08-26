using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Comments
{
    public class AddCommentDto
    {
        [Required]
        [MinLength(10)]
        public string Comment { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ItemId { get; set; }
    }
}
