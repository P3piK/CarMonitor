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
    }
}
