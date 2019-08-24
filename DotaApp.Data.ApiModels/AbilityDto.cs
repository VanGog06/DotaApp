using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotaApp.Data.ApiModels
{
    public class AbilityDto
    {
        [JsonProperty("dname")]
        public string AbilityName { get; set; }

        [JsonProperty("behavior")]
        public dynamic Behavior { get; set; }

        [JsonProperty("dmg_type")]
        public string DamageType { get; set; }

        [JsonProperty("bkbpierce")]
        public string Pierce { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("img")]
        public string Image { get; set; }

        [JsonProperty("mc")]
        public dynamic ManaCost { get; set; }

        [JsonProperty("cd")]
        public dynamic Cooldown { get; set; }

        [JsonProperty("attrib")]
        public ICollection<AbilityAttributeDto> AbilityAttributes { get; set; }
    }
}
