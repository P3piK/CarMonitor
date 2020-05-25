using CarMonitor.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Data.Data
{
    public class ConsumptionData
    {
        public CMContext Context { get; }


        public ConsumptionData()
        {
            Context = new CMContext();
        }

        ~ConsumptionData()
        {
            Context.Dispose();
        }

        public IEnumerable<Consumption> GetByProfile(Profile profile)
        {
            return Context.Consumptions.Where(c => c.Profile.ProfileID.Equals(profile.ProfileID));
        }

        public void Insert(Consumption consumption)
        {
            consumption.ChangeDate = DateTime.Now;

            Context.Profiles.Attach(consumption.Profile);
            Context.Consumptions.Add(consumption);

            Context.SaveChanges();
        }
    }
}
