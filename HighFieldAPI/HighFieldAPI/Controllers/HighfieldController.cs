using AutoMapper;
using HighFieldAPI.Dto;
using HighFieldAPI.Logic;
using HighFieldAPI.Models;
using HighFieldAPI.Models.API;
using HighFieldAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HighFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighfieldController : ControllerBase
    {
        public ILogger<HighfieldController> Logger;
        public HighFieldSettings HighfieldSettings;
        private readonly IMapper mapper;

        public HighfieldController(ILogger<HighfieldController> logger, HighFieldSettings highfieldSettings, IMapper mapper)
        {
            Logger = logger;
            HighfieldSettings = highfieldSettings;
            this.mapper = mapper;
        }

        

        [HttpGet] //api/highfield
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            Logger.LogInformation("Getting all the users");
            using (var highfieldRepository = new HighfielsApiRepository(HighfieldSettings))
            {
               var users= await highfieldRepository.GetUsersAsync();
                if (users == null)
                {
                    return NotFound();
                }

                return mapper.Map<List<UserDto>>(users);
            }  
           
        }
        [Route("[action]", Name = "getUsers")]
        [HttpGet]
        public async Task<ActionResult<HighfieldResponse>> GetUsers()
        {
            Logger.LogInformation("Getting all the users");
            using (var highfieldRepository = new HighfielsApiRepository(HighfieldSettings))
            {
                var users = await highfieldRepository.GetUsersAsync();
                if (users == null)
                {
                    return NotFound();
                }
                var response = new HighfieldResponse(users, mapper);
                if (response == null)
                {
                    return NotFound();
                }

                return response;
            }

        }
        [Route("[action]", Name = "getColours")]
        [HttpGet]
        public async Task<ActionResult<List<TopColoursDto>>> Getcolours()
        {
            Logger.LogInformation("Getting all the colours");
            using (var highfieldRepository = new HighfielsApiRepository(HighfieldSettings))
            {
                var users = await highfieldRepository.GetUsersAsync();
                if (users == null)
                {
                    return NotFound();
                }
                var response = new HighfieldResponse(users, mapper);
                if (response == null)
                {
                    return NotFound();
                }

                return response.TopColours;
            }

        }
    }
}
