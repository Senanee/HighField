using AutoMapper;
using HighFieldAPI.Dto;
using HighFieldAPI.Extensions;
using HighFieldAPI.Logic;
using HighFieldAPI.Models;
using HighFieldAPI.Models.API;
using HighFieldAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<List<UserDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            Logger.LogInformation("Getting all the users");
            using (var highfieldRepository = new HighfielsApiRepository(HighfieldSettings))
            {
               var users=( await highfieldRepository.GetUsersAsync()).AsQueryable();
                if (users == null)
                {
                    return NotFound();
                }
                await HttpContext.InsertParametersPaginationInHeader(users);
                var result = users.OrderBy(x => x.FirstName).ThenBy(x=>x.LastName).Paginate(paginationDto).ToList();
                return mapper.Map<List<UserDto>>(result);
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
        public async Task<ActionResult<List<TopColoursDto>>> Getcolours([FromQuery] PaginationDto paginationDto)
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
                var topColours = (response.TopColours).AsQueryable();
                await HttpContext.InsertParametersPaginationInHeader(topColours);

                var result = topColours.OrderByDescending(x => x.Count).ThenBy(x => x.Colour).Paginate(paginationDto).ToList();

                return result;
            }

        }
    }
}
