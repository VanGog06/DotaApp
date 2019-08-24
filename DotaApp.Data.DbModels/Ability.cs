using DotaApp.Data.Common;
using System.Collections.Generic;

namespace DotaApp.Data.DbModels
{
    public class Ability : BaseModel<int>
    {
        public Ability()
        {
            this.AbilityAttributes = new HashSet<AbilityAttribute>();
        }

        public string AbilityName { get; set; }

        public string Behavior { get; set; }

        public string DamageType { get; set; }

        public string Pierce { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string ManaCost { get; set; }

        public string Cooldown { get; set; }

        public int HeroId { get; set; }

        public virtual Hero Hero { get; set; }

        public virtual ICollection<AbilityAttribute> AbilityAttributes { get; set; }
    }
}
