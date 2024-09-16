using NET_Developer_Intern_API_Coding_Assessment.Model;

namespace NET_Developer_Intern_API_Coding_Assessment.Interfaces
{
    public interface IPlatformServices
    {

        public bool AddPlatform(PlatformInfo platform);
        public ICollection<PlatformInfo> GetPlatformInfo();
        public bool Save();
    }
}
