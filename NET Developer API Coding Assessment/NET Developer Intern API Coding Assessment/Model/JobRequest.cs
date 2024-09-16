using System.ComponentModel.DataAnnotations;

namespace NET_Developer_Intern_API_Coding_Assessment.Model
{
    public class JobRequest
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Required]
        public List<string>? Keywords { get; set; }
        public int PlatformInfoId { get; set; } 
        public PlatformInfo?  Platforminfo { get; set; }



    }
}
