using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Users
{
    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        public string CurrentPassword { get; set; }

        [Required]
        [MinLength(4)]
        public string NewPassword { get; set; }
    }
}
