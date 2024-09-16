using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_Developer_Intern_API_Coding_Assessment.Interface;
using NET_Developer_Intern_API_Coding_Assessment.Interfaces;
using NET_Developer_Intern_API_Coding_Assessment.Model;
using NET_Developer_Intern_API_Coding_Assessment.Model.Dtos;

namespace NET_Developer_Intern_API_Coding_Assessment.Controllers
{
    public class JobAdController : BaseController
    {
        private readonly IAdOtimizer _adOtimizer; // Service Injection in place..
        private readonly IPlatformServices _platformServices;
        private readonly IMapper _mapper;

        public JobAdController(IAdOtimizer adOtimizer 
                              ,IPlatformServices platformServices
                              ,IMapper mapper)
        {
            _adOtimizer = adOtimizer;
            _platformServices = platformServices;
            _mapper = mapper;
        }

        [HttpPost("Optimize-Ad")]
        public IActionResult OptimizedAd(JobRequestDto jobRequest)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var mappedRequest = _mapper.Map<JobRequest>(jobRequest);
                string OptimizedContent = _adOtimizer.Optimize(mappedRequest);
                var response = new OptimizedAdResponse(OptimizedContent);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
