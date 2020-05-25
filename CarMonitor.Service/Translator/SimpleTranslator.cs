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
                FuelType = profile.FuelType,
                Description = profile.Description,
                TankCapacity = profile.TankCapacity,
            };
        }

        public static Profile Translate(ProfileDto profileDto)
        {
            return new Profile()
            {
                Name = profileDto.Name,
                FuelType = profileDto.FuelType,
                TankCapacity = profileDto.TankCapacity,
                Description = profileDto.Description,
            };
        }

        public static Consumption Translate(ConsumptionDto consumptionDto)
        {
            return new Consumption()
            {
                Date = consumptionDto.Date,
                Distance = consumptionDto.Distance,
                Price = consumptionDto.PricePerLitre,
                FuelVolume = consumptionDto.FuelVolume,
                TankLevel = 1,
                FuelType = FuelType.Lpg,
            };
        }

        public static ConsumptionDto Translate(Consumption consumption)
        {
            return new ConsumptionDto()
            {
                Date = consumption.Date,
                Distance = consumption.Distance,
                PricePerLitre = consumption.Price,
                FuelVolume = consumption.FuelVolume,
            };
        }
    }
}
