using CarMonitor.Service;
using CarMonitor.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Host
{
    class Program
    {
        private const string BASE_PATH = "http://localhost:8080/CarMonitor";
        private const string PROFILE_SERVICE_SUFFIX = "/ProfileService";

        static void Main(string[] args)
        {
            RunHost();
        }

        private static void RunHost()
        {
            Uri baseAddress = new Uri(BASE_PATH);
            Uri profileAddress = new Uri(String.Concat(BASE_PATH, PROFILE_SERVICE_SUFFIX));
            //Uri consumptionAddress = new Uri(baseAddress, "/ConsumptionService");

            // Create the ServiceHost.
            using (ServiceHost profileHost = new ServiceHost(typeof(ProfileService), profileAddress))
            //using (ServiceHost consumptionHost = new ServiceHost(typeof(ConsumptionService), consumptionAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                profileHost.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                profileHost.Open();

                Console.WriteLine("The service is ready at {0}", profileAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                profileHost.Close();
            }
        }
    }
}
