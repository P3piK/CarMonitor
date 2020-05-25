using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Service.Dto
{
    [DataContract]
    public class AvgConsumptionDto
    {
        [DataMember]
        public double TotalPrice { get; set; }

        [DataMember]
        public double AvgPrice { get; set; }

        [DataMember]
        public double AvgConsumption { get; set; }

        [DataMember]
        public double LastConsumption { get; set; }
    }
}
