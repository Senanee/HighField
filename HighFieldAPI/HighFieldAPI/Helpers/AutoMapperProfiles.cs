using AutoMapper;
using HighFieldAPI.Dto;
using HighFieldAPI.Models.API;
using HighFieldAPI.Models.Dto;
using System;
using System.Collections.Generic;

namespace HighFieldAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<HighFieldUserEntity, AgePlusTwentyDto>()
                .ForMember(x => x.UserId, dto => dto.MapFrom(prop => prop.Id))
                .ForMember(x => x.OriginalAge, dto => dto.MapFrom(prop => (DateTime.Now.Year - prop.Dob.Value.Year)))
                .ForMember(x => x.AgePlusTwenty, dto => dto.MapFrom(prop => (DateTime.Now.Year - prop.Dob.Value.Year) + 20));

            CreateMap<UserDto, HighFieldUserEntity>().ReverseMap()
                 //.ForMember(destinationMember: x => x.AgePlusTwentyDto, memberOptions: options => options.MapFrom(s => s))
                .ForMember(x => x.OriginalAge, dto => dto.MapFrom(prop => (DateTime.Now.Year - prop.Dob.Value.Year)))
                .ForMember(x => x.AgePlusTwenty, dto => dto.MapFrom(prop => (DateTime.Now.Year - prop.Dob.Value.Year) + 20));



        }


    }
}
