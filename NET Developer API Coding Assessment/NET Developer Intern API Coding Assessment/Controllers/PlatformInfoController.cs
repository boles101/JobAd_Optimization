using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_Developer_Intern_API_Coding_Assessment.Interfaces;
using NET_Developer_Intern_API_Coding_Assessment.Model;
using NET_Developer_Intern_API_Coding_Assessment.Model.Dtos;

namespace NET_Developer_Intern_API_Coding_Assessment.Controllers
{
    
    public class PlatformInfoController : BaseController
    {
        private readonly IPlatformServices _platformServices;
        private readonly IMapper _mapper;

        public PlatformInfoController(IPlatformServices platformServices,IMapper mapper)
        {
            _platformServices = platformServices;
            _mapper = mapper;
        }

        #region Add Platform

        [HttpPost("Add-Platform")]
        public IActionResult AddPlatform(PlatformInfoDto platformDto)
        {
            if (platformDto == null)
                return BadRequest();

            // An IsExist method can be made in the repo to assure that the platfrom is in database already or not ! 

            var platform = _mapper.Map<PlatformInfo>(platformDto);

            if (!_platformServices.AddPlatform(platform))
                return BadRequest();

            return Ok("Platform Added successfully :)");

        }

        #endregion

        #region Get All Platforms

        [HttpGet("Get-All-Platforms")]
        public IActionResult GetPlatforms()
        {
            var platforms = _platformServices.GetPlatformInfo();
            if (platforms == null)
                return BadRequest();
            var mappedPlatform = _mapper.Map<List<PlatformInfoDto>>(platforms);
           return Ok(mappedPlatform); 
            
        }
        #endregion
        

        



    }
}
