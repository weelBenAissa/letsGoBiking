using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RoutingServer
{
    [ServiceContract]
    internal interface IService
    {
        [OperationContract]
         void GetItinerary(string start, string end);
    }
}
