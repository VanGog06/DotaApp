using DotaApp.Data.Common;
using System.Collections.Generic;

namespace DotaApp.Data.DbModels
{
    public class Role : BaseModel<int>
    {
        public Role()
        {
            this.Heroes = new HashSet<HeroRole>();
        }

        public string Name { get; set; }

        public virtual ICollection<HeroRole> Heroes { get; set; }
    }
}
