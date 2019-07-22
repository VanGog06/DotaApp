using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Users
{
    public class UserWithoutPasswordDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
