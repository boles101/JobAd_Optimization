using NET_Developer_Intern_API_Coding_Assessment.Data;
using NET_Developer_Intern_API_Coding_Assessment.Interfaces;
using NET_Developer_Intern_API_Coding_Assessment.Model;

namespace NET_Developer_Intern_API_Coding_Assessment.Services
{
    public class PlatformServices : IPlatformServices
    {
        private readonly AssesmentDbContext _context;

        public PlatformServices(AssesmentDbContext context)
        {
            _context = context;
        }

        public bool AddPlatform(PlatformInfo platform)
        {
            _context.Add(platform);
            return Save();
        }

        public ICollection<PlatformInfo> GetPlatformInfo()
        {
            return _context.platformInfos.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges()>0?true:false;
        }


        //public List<PlatformInfo> GetPlatformInfo()
        //{
        //    var  platformInfos = new List<PlatformInfo>();

        //    var platforms = Enum.GetValues(typeof(SocialMediaPlatform)).Cast<SocialMediaPlatform>();


        //    foreach (var platform in platforms)
        //    {
        //        platformInfos.Add(new PlatformInfo
        //        {
        //            PlatformName =  platform.ToString(),
        //            CharacterLimit = GetCharachterLimit(platform)
        //        });
        //    }
        //    return platformInfos;
        //}
        //private int GetCharachterLimit(SocialMediaPlatform platform)
        //{
        //    switch (platform)
        //    {
        //        case SocialMediaPlatform.Twitter:
        //            return 280;
        //        case SocialMediaPlatform.LinkedIn:
        //            return 1300;
        //        default:
        //            throw new NotSupportedException($"Character Limit not specified for Platform: {platform}.");

        //    }

        //}

    }
}
