using DotaApp.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotaApp.Data.DbModels
{
    public class IdentityRole : BaseModel<int>
    {
        public IdentityRole()
        {
            this.Users = new HashSet<UserRole>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }
    }
}
