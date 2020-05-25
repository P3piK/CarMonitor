using CarMonitor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Service.Interface
{
    [ServiceContract]
    public interface IConsumptionService
    {
        //[OperationContract]
        //IEnumerable<ConsumptionDto> FindByProfile(string name);

        [OperationContract]
        void Add(string profileName, ConsumptionDto consumptionDto);

        [OperationContract]
        AvgConsumptionDto CalculateAvgConsumption(string name);
    }
}
