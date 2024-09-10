using NET_Developer_Intern_API_Coding_Assessment.Interfaces;
using NET_Developer_Intern_API_Coding_Assessment.Model;
namespace NET_Developer_Intern_API_Coding_Assessment.Services
{
    public class PlatformServices : IPlatformServices
    {
        public List<PlatformInfo> GetPlatformInfo()
        {
            var  platformInfos = new List<PlatformInfo>();

            var platforms = Enum.GetValues(typeof(SocialMediaPlatform)).Cast<SocialMediaPlatform>();


            foreach (var platform in platforms)
            {
                platformInfos.Add(new PlatformInfo
                {
                    PlatformName =  platform.ToString(),
                    CharacterLimit = GetCharachterLimit(platform)
                });
            }
            return platformInfos;
        }
        private int GetCharachterLimit(SocialMediaPlatform platform)
        {
            switch (platform)
            {
                case SocialMediaPlatform.Twitter:
                    return 280;
                case SocialMediaPlatform.LinkedIn:
                    return 1300;
                default:
                    throw new NotSupportedException($"Character Limit not specified for Platform: {platform}.");

            }

        }


    }
}
