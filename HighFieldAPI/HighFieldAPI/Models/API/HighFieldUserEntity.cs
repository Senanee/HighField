using Newtonsoft.Json;
using System;

namespace HighFieldAPI.Models.API
{
    public class HighFieldUserEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dob")]
        public DateTime? Dob { get; set; }

        [JsonProperty("favouriteColour")]
        public string FavouriteColour { get; set; }
    }
}
