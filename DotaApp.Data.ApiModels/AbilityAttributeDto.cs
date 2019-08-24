using Newtonsoft.Json;

namespace DotaApp.Data.ApiModels
{
    public class AbilityAttributeDto
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("value")]
        public dynamic Value { get; set; }

        [JsonProperty("generated", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool Generated { get; set; }
    }
}
