using CarMonitor.Data.Data;
using CarMonitor.Data.Entity;
using CarMonitor.Service.Dto;
using CarMonitor.Service.Interface;
using CarMonitor.Service.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Service.Service
{
    public class ConsumptionService : IConsumptionService
    {
        private ConsumptionData consumptionData;
        private ProfileData profileData;

        #region Properties
        private ConsumptionData ConsumptionData
        {
            get
            {
                if (consumptionData == null)
                {
                    consumptionData = new ConsumptionData();
                }

                return consumptionData;
            }
        }

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

        #endregion

        public void Add(string profileName, ConsumptionDto consumptionDto)
        {
            var consumption = SimpleTranslator.Translate(consumptionDto);
            var profile = ProfileData.GetProfile(profileName);
            consumption.Profile = profile;

            ConsumptionData.Insert(consumption);
        }

        public AvgConsumptionDto CalculateAvgConsumption(string name)
        {
            var data = FindByProfile(name);

            return new AvgConsumptionDto()
            {
                AvgConsumption = CalculateAvgConsumption(data),
                LastConsumption = CalculateLastConsumption(data),
                AvgPrice = CalculateAvgPrice(data),
            };
        }

        #region Private

        private IEnumerable<Consumption> FindByProfile(string name)
        {
            var profile = ProfileData.GetProfile(name);
            return ConsumptionData.GetByProfile(profile).ToArray();
        }

        private double CalculateAvgPrice(IEnumerable<Consumption> data)
        {
            double ret = 0;

            if (data.Any(d => d.Distance != 0))
            {
                ret = data.Average(d => d.Price * d.FuelVolume / d.Distance);
            }

            return ret;
        }

        private double CalculateLastConsumption(IEnumerable<Consumption> data)
        {
            double ret = 0;
            var consumption = data.OrderByDescending(d => d.Date).FirstOrDefault();

            if (consumption != null && consumption.Distance != 0)
            {
                ret = consumption.FuelVolume / consumption.Distance * 100;
            }

            return ret;
        }

        private double CalculateAvgConsumption(IEnumerable<Consumption> data)
        {
            double ret = 0;
            if (data.Any(d => d.Distance != 0))
            {
                ret = data.Sum(d => d.FuelVolume) / data.Sum(d => d.Distance) * 100;
            }

            return ret;
        }

        #endregion
    }
}
