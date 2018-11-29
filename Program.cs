using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFAssignment_1DOTNET;

namespace SelfHost
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/WCFAssignment_1DOTNET/Service1/SayHello");
            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(WCFAssignment_1DOTNET.Service1), httpUrl);
            //Add a service endpoint
            host.AddServiceEndpoint(typeof(WCFAssignment_1DOTNET.IService1)
            , new WSHttpBinding(), "");
            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            //Start the Service
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
        }
    }
}
