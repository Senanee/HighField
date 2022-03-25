using Newtonsoft.Json;

namespace HighFieldAPI.Dto
{
    public class AgePlusTwentyDto
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("originalAge")]
        public int OriginalAge { get; set; }

        [JsonProperty("agePlusTwenty")]
        public int AgePlusTwenty { get; set; }
    }
}
