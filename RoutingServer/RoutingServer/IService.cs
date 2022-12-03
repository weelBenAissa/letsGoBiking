using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static RoutingServer.Direction;

namespace RoutingServer
{
    [ServiceContract]
    internal interface IRoutingService
    {
        [OperationContract()]
         List<Step> GetItinerary(string start, string end);
    }
}
