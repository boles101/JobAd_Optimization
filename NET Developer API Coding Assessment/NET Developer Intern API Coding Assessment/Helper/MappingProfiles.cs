using AutoMapper;
using NET_Developer_Intern_API_Coding_Assessment.Model;
using NET_Developer_Intern_API_Coding_Assessment.Model.Dtos;

namespace NET_Developer_Intern_API_Coding_Assessment.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PlatformInfo,PlatformInfoDto>().ReverseMap();
            CreateMap<JobRequest, JobRequestDto>().ReverseMap();
        }
    }
}
