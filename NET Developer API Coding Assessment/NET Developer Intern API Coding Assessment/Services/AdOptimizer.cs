using NET_Developer_Intern_API_Coding_Assessment.Data;
using NET_Developer_Intern_API_Coding_Assessment.Interface;
using NET_Developer_Intern_API_Coding_Assessment.Model;
using System.Security.AccessControl;

namespace NET_Developer_Intern_API_Coding_Assessment.Services
{
    public class AdOptimizer : IAdOtimizer
    {
        private readonly ILogger<AdOptimizer> _logger;
        private readonly AssesmentDbContext _context;

        public AdOptimizer(ILogger<AdOptimizer> logger , AssesmentDbContext context) // logger injection ! 
        {
            _logger = logger;
            _context = context;
        }


        //optimization Logic will be placed here !  
        public string Optimize(JobRequest jobRequest)
        {
            string adContent = $"{jobRequest.Title} - {string.Join(", ", jobRequest.Keywords)} - {jobRequest.Description}";
            _logger.LogInformation($"Content length is {adContent.Length}"); // added to check adcontent before hand ! 
            var platform = _context.platformInfos.FirstOrDefault(p=>p.Id == jobRequest.PlatformInfoId);
            if (platform == null)
            {
                _logger.LogError($"Unsupported platform : {jobRequest.PlatformInfoId}");
                throw new InvalidOperationException("Unsupported platform");
            }

            else
                return TrimContent(adContent, platform.CharacterLimit);
        }


        //public string Optimize(JobRequest jobRequest)
        //{

        //    string adContent = $"{jobRequest.Title} - {string.Join(", ", jobRequest.Keywords)} - {jobRequest.Description}";

        //    _logger.LogInformation($"Content length is {adContent.Length}"); // added to check adcontent before hand ! 

        //    var platform = _context.platformInfos.FirstOrDefault(p => p.PlatformName == jobRequest.Platform.ToString());

        //    if (platform == null)
        //    {
        //        _logger.LogError($"Unsupported platform : {jobRequest.Platform}");
        //        throw new InvalidOperationException("Unsupported platform");
        //    }

        //    return TrimContent(adContent, platform.CharacterLimit);
        //}


        private string TrimContent(string content, int MaxLength) // needed attention !! that's just a beta method!
        {

            if (content.Length <= MaxLength)
                return content;
            else
                return content.Substring(0, MaxLength - 3) + "...";
        }
    }
}
