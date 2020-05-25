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
        private ProfileData profileData;

        private ProfileData ProfileData
        {
            get
            {
                if (profileData == null)
                {
                    profileData = new ProfileData();
                }

                return profileData;
            }

        }

        public void CreateProfile(ProfileDto profileDto)
        {
            var profile = SimpleTranslator.Translate(profileDto);

            ProfileData.InsertProfile(profile);
        }

        public ProfileDto GetProfile(string name)
        {
            var profile = ProfileData.GetProfile(name);
            var ret = default(ProfileDto);

            if (profile != null)
            {
                ret = SimpleTranslator.Translate(profile);
            }

            return ret;
        }
    }
}
