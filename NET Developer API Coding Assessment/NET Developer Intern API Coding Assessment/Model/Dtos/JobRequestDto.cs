using System.ComponentModel.DataAnnotations;

namespace NET_Developer_Intern_API_Coding_Assessment.Model.Dtos
{
    public class JobRequestDto
    {
        public string? Title {get; set;}
        [Required]
        [MaxLength(1000)]
        public string? Description {get; set;}
        [Required]
        public List<string>? Keywords {get; set;}
        [Required]
        public int PlatformInfoId { get; set; } 

    }
}
