using CarMonitor.Data.Data;
using CarMonitor.Data.Entity;
using CarMonitor.Service.Dto;
using CarMonitor.Service.Interface;
using CarMonitor.Service.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarMonitor.Service.Service
{
    public class ProfileService : IProfileService
    {
        public void CreateProfile(ProfileDto profileDto)
        {
            var profileData = new ProfileData();
            var profile = SimpleTranslator.Translate(profileDto);

            profileData.InsertProfile(profile);
        }

        public ProfileDto GetProfile(string name)
        {
            var profileData = new ProfileData();
            var profile = profileData.GetProfile(name);

            return SimpleTranslator.Translate(profile);
        }
    }
}
