﻿namespace NET_Developer_Intern_API_Coding_Assessment.Model
{
    public class PlatformInfo
    {

        public int  Id { get; set; }
        public string? PlatformName { get; set; }
        public int CharacterLimit { get; set; }
        public ICollection<JobRequest>?  jobRequests{ get; set; }

        // a static method can be applied here to retrieve the platform data however
        // I will make an interface for it aswell ! 

    }
}
