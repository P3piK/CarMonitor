using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Data.Entity
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string Name { get; set; }
        public FuelType FuelType { get; set; }
        public int TankCapacity { get; set; }
        public string Description { get; set; }

        public DateTime? ChangeDate { get; set; }

    }
}
