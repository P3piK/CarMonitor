using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Data.Entity
{
    public class Consumption
    {
        public int ConsumptionID { get; set; }
        public Profile Profile { get; set; }
        public double Distance { get; set; }
        public double Price { get; set; }
    }
}
