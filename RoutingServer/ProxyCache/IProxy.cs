using System.Collections.Generic;
using System.ServiceModel;
using static ProxyCache.JCDeceaux;
using System.Runtime.Serialization;

namespace ProxyCache
{
    [ServiceContract]
    internal interface IProxy

    {

        [OperationContract()]
         List<Contract> getContracts();
        [OperationContract()]
         List<Station> getStationsByContract(string contract);

    }
}
