using HighFieldAPI.Dto;
using System;

namespace HighFieldAPI.Models.Dto
{
    public class UserDto
    {


        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string Email { get; set; }

        public DateTime? Dob { get; set; }

        public string FavouriteColour { get; set; }

        //public AgePlusTwentyDto AgePlusTwentyDto { get; set; }

        public int OriginalAge { get; set; }

        public int AgePlusTwenty { get; set; }

    }
}
