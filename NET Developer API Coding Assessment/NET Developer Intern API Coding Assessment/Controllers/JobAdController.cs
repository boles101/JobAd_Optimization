using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_Developer_Intern_API_Coding_Assessment.Interface;
using NET_Developer_Intern_API_Coding_Assessment.Interfaces;
using NET_Developer_Intern_API_Coding_Assessment.Model;

namespace NET_Developer_Intern_API_Coding_Assessment.Controllers
{
    public class JobAdController : BaseController
    {
        private readonly IAdOtimizer _adOtimizer; // Service Injection in place..
        private readonly IPlatformServices _platformServices;

        public JobAdController(IAdOtimizer adOtimizer ,IPlatformServices platformServices)
        {
            _adOtimizer = adOtimizer;
            _platformServices = platformServices;

        }

        [HttpPost("Optimize-Ad")]
        public IActionResult OptimizedAd(JobRequest jobRequest)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                string OptimizedContent = _adOtimizer.Optimize(jobRequest);
                var response = new OptimizedAdResponse(OptimizedContent);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All-Platforms")]
        public IActionResult GetPlatforms()
        {
            return Ok(_platformServices.GetPlatformInfo());
        }
    }
}
