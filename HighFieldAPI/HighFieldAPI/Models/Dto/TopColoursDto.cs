using Newtonsoft.Json;

namespace HighFieldAPI.Dto
{
    public class TopColoursDto
    {
        [JsonProperty("colour")]
        public string Colour { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
