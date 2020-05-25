using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Data.Entity
{
    public enum FuelType
    {
        Petrol = 0,
        Diesel = 1,
        Lpg = 2,
    }

    public class Consumption
    {
        public int ConsumptionID { get; set; }
        public Profile Profile { get; set; }
        public FuelType? FuelType { get; set; }
        public double FuelVolume { get; set; }
        public double Distance { get; set; }
        public double Price { get; set; }
        public double TankLevel { get; set; }
        public DateTime Date { get; set; }

        public DateTime? ChangeDate { get; set; }
    }
}
