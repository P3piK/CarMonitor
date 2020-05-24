using CarMonitor.Data.Data;
using CarMonitor.Data.Entity;
using CarMonitor.Service.Dto;
using CarMonitor.Service.Interface;
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
            var profile = new Profile()
            {
                Login = profileDto.Name,
            };

            profileData.InsertProfile(profile);
        }

        public ProfileDto GetProfile(string login)
        {
            return new ProfileDto() { Name = login };
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
