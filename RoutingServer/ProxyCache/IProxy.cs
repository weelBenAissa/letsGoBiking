using System.ServiceModel;
using static ProxyCache.JCDeceaux;

namespace ProxyCache
{
    [ServiceContract]
    internal interface IProxy
        
    {
        [OperationContract()]
        public List<Station> getStations();
        [OperationContract()]
        public List<Contract> getContracts();
        [OperationContract()]
        public List<Station> getStationsByContract(string contract);
    }
}
