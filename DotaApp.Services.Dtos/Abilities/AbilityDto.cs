using System.Collections.Generic;

namespace DotaApp.Services.Dtos.Abilities
{
    public class AbilityDto
    {
        public string AbilityName { get; set; }

        public string Behavior { get; set; }

        public string DamageType { get; set; }

        public string Pierce { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string ManaCost { get; set; }

        public string Cooldown { get; set; }

        public virtual ICollection<AbilityAttributeDto> AbilityAttributes { get; set; }
    }
}
