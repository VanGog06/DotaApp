using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotaApp.Data.ApiModels
{
    public class ItemDto
    {
        [JsonProperty("img")]
        public string Image { get; set; }

        [JsonProperty("dname")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("lore")]
        public string Lore { get; set; }

        [JsonProperty("attrib")]
        public ICollection<ItemAttributeDto> ItemAttributes { get; set; }
    }
}
