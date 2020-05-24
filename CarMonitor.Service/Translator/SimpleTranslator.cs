using CarMonitor.Data.Entity;
using CarMonitor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Service.Translator
{
    public static class SimpleTranslator
    {
        public static ProfileDto Translate(Profile profile)
        {
            return new ProfileDto()
            {
                Name = profile.Name,
            };
        }

        public static Profile Translate(ProfileDto profileDto)
        {
            return new Profile()
            {
                Name = profileDto.Name,
            };
        }
    }
}
