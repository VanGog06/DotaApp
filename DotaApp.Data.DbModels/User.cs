using DotaApp.Data.Common;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotaApp.Data.DbModels
{
    public class User : BaseModel<int>
    {
        public User()
        {
            this.Roles = new HashSet<UserRole>();
        }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
