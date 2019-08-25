using Newtonsoft.Json;

namespace DotaApp.Data.ApiModels
{
    public class ItemAttributeDto
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("value")]
        public dynamic Value { get; set; }

        [JsonProperty("footer")]
        public string Footer { get; set; }
    }
}
