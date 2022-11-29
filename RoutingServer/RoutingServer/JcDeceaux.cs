using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RoutingServer
{
    [DataContract]
    public class contract
    {
        [DataMember]
        string name { get; set; }
    }
    [DataContract]
    public class station
    {
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Position position { get; set; }
    }
    [DataContract]
    public class Position
    {
        [DataMember]
        public Double latitude { get; set; }
        [DataMember]
        public Double longitude { get; set; }
    }
    internal class JcDeceaux
    {
        string urlContract = "https://api.jcdecaux.com/vls/v3/contracts";
        string key = "3d2ab2ea77d811391e1cea4265a75794bda2f0a9";
        string urlStation = "https://api.jcdecaux.com/vls/v3/stations";
        HttpClient client = new HttpClient();
        public List<contract> GetContracts()
        {

            HttpResponseMessage response = client.GetAsync(urlContract + "?apiKey=" + key).GetAwaiter().GetResult();
            return response.Content.ReadAsAsync<List<contract>>().GetAwaiter().GetResult();
        }
        public List<station> GetStationsForAContract(string contract)
        {
            HttpResponseMessage response = client.GetAsync(urlStation + "?apiKey=" + key + "&contract=" + contract).GetAwaiter().GetResult();
            return response.Content.ReadAsAsync<List<station>>().GetAwaiter().GetResult();
        }
        public Contrat GetContratForPosition(double latitude, double longitude)
        {
            List<contract> contracts = GetContracts();
            foreach (contract c in contracts)
            {
                List<station> stations = GetStationsForAContract(c.name);
                foreach (station s in stations)
                {
                    if (s.position.latitude == latitude && s.position.longitude == longitude)
                    {
                        return c;
                    }
                }
            }
            return null;
        }
    }

    
}
