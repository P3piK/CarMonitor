using CarMonitor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarMonitor.Service.Interface
{
    [ServiceContract]
    public interface IProfileService
    {
        [OperationContract]
        ProfileDto GetProfile(string login);

        [OperationContract]
        void CreateProfile(ProfileDto profile);
    }
}
