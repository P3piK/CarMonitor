using CarMonitor.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Service.Dto
{
    [DataContract]
    public class ProfileDto
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public DateTime ChangeDate { get; set; }

        [DataMember]
        public FuelType FuelType { get; set; }

        [DataMember]
        public int TankCapacity { get; set; }
        
        [DataMember]
        public string Description { get; set; }
    }
}
