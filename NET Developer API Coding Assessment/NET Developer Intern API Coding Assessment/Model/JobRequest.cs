using NET_Developer_Intern_API_Coding_Assessment.Helper;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace NET_Developer_Intern_API_Coding_Assessment.Model
{
    public class JobRequest
    {

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Required]
        public List<string>? Keywords { get; set; }


        // when a non specified platform is sumbitted it resulted in a bad request (400) status code error.. however I couldn't
        //find that error to handle properly with multiple break points even with the defined ValidEnumValue Helper Method

        [Required(ErrorMessage ="Please Specify the platform")]
        [ValidEnumValue(typeof(SocialMediaPlatform), ErrorMessage = "The specified platform is not supported.")]
        public SocialMediaPlatform Platform { get; set; }



    }

    public enum SocialMediaPlatform 
    {
        Twitter,
        LinkedIn,
        
    }
}
