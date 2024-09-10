using NET_Developer_Intern_API_Coding_Assessment.Interface;
using NET_Developer_Intern_API_Coding_Assessment.Model;
using System.Security.AccessControl;

namespace NET_Developer_Intern_API_Coding_Assessment.Services
{
    public class AdOptimizer : IAdOtimizer
    {
        private readonly ILogger<AdOptimizer> _logger;

        public AdOptimizer(ILogger<AdOptimizer> logger) // logger injection ! 
        {
            _logger = logger;
        }


        public string Optimize(JobRequest jobRequest)
        {

            string adContent = $"{jobRequest.Title} - {string.Join(", ", jobRequest.Keywords)} - {jobRequest.Description}";

            _logger.LogInformation($"Content length is {adContent.Length}"); // added to check adcontent before hand ! 

            if (jobRequest.Platform== SocialMediaPlatform.Twitter)
            {
                return TrimContent(adContent, 280);
            }
            else if(jobRequest.Platform == SocialMediaPlatform.LinkedIn)
            {
                return TrimContent(adContent, 1300);
            }
            else
                throw new InvalidOperationException("Unsupported Platform");

        }


        private string TrimContent(string content, int MaxLength) // needed attention !! that's just a beta method!
        {

            if (content.Length <= MaxLength)
                return content;
            else
                return content.Substring(0, MaxLength - 3) + "...";
        }
    }
}
