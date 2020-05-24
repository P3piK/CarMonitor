using CarMonitor.Service.Dto;
using CarMonitor.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Service.Service
{
    public class ConsumptionService : IConsumptionService
    {
        public void Add(ConsumptionDto consumption)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsumptionDto> FindByProfile(string name)
        {
            throw new NotImplementedException();
        }
    }
}
