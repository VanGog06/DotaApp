using Newtonsoft.Json;

namespace DotaApp.Data.ApiModels
{
    public class TeamDto
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("last_match_time")]
        public int LastMatchTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
    }
}
