using AutoMapper;
using HighFieldAPI.Dto;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HighFieldAPI.Models.API
{
    public class HighfieldResponse
    {
        [JsonProperty("users")]
        public List<HighFieldUserEntity> Users { get; set; }
        [JsonProperty("ages")]
        public List<AgePlusTwentyDto> Ages { get; set; }
        [JsonProperty("topColours")]
        public List<TopColoursDto> TopColours { get; set; }
        
        public HighfieldResponse(List<HighFieldUserEntity> highFieldUserEntity, IMapper mapper)
        {
            Users = highFieldUserEntity;
            Ages= mapper.Map<List<AgePlusTwentyDto>>(highFieldUserEntity);
            TopColours = highFieldUserEntity.GroupBy(x=>x.FavouriteColour)
                .Select(x=>new TopColoursDto{ Colour = x.Key, Count= x.Count()})
                .OrderByDescending(x=>x.Count)
                .ThenBy(x=>x.Colour).ToList();
        }
    }
}
