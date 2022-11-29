using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
// HttpClient is in the System.web.Http namespace.
using System.Text.Json;
// GeoCordinates is in the System.Device.Location namespace, coming from System.Device which is an assembly reference.
using System.Device.Location;
namespace RoutingServer
{
    [DataContract]
    public class Contract
    {
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Station
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
        static async Task<string> JCDecauxAPICall(string url, string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public List<Contract> GetContracts()
        {
            string query = "apiKey=" + key;
            string response = JCDecauxAPICall(urlContract, query).Result;
            List<Contract> allContracts = JsonSerializer.Deserialize<List<Contract>>(response);
            return allContracts;
        }
        public List<Station> GetStationsForAContract(string contract)
        {
            string query = "apiKey=" + key + "&contract=" + contract;
            string response = JCDecauxAPICall(urlStation, query).Result;
            List<Station> allStations = JsonSerializer.Deserialize<List<Station>>(response);
            return allStations;
        }
        public Contract GetContratForPosition(double latitude, double longitude)
        {
            List<Contract> contracts = GetContracts();
            foreach (Contract c in contracts)
            {
                List<Station> stations = GetStationsForAContract(c.name);
                foreach (Station s in stations)
                {
                    if (s.position.latitude == latitude && s.position.longitude == longitude)
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        public Station getClosestStation(double latitude, double longitude)
        {
            Contract contract = GetContratForPosition(latitude, longitude);
            List<Station> stations = GetStationsForAContract(contract.name);
            Station closestStation = null;
            double distance = 0;
            foreach (Station s in stations)
            {
                GeoCoordinate stationPosition = new GeoCoordinate(s.position.latitude, s.position.longitude);
                GeoCoordinate userPosition = new GeoCoordinate(latitude, longitude);
                double currentDistance = stationPosition.GetDistanceTo(userPosition);
                if (closestStation == null || currentDistance < distance)
                {
                    closestStation = s;
                    distance = currentDistance;
                }
            }
            return closestStation;
        }

    }
}
