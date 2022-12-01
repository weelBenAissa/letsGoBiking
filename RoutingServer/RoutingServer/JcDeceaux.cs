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
        [DataMember]
        public TotalStands totalStands { get; set; }
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
        private string urlContract = "https://api.jcdecaux.com/vls/v3/contracts";
        private string key = "3d2ab2ea77d811391e1cea4265a75794bda2f0a9";
        private string urlStation = "https://api.jcdecaux.com/vls/v3/stations";
        static async Task<string> JCDecauxAPICall(string url, string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public List<Station> getStations()
        {
            string query = "apiKey=" + key;
            string response = JCDecauxAPICall(urlStation, query).Result;
            List<Station> allStations = JsonSerializer.Deserialize<List<Station>>(response);
            return allStations;
        }
        public List<Contract> getContracts()
        {
            string query = "apiKey=" + key;
            string response = JCDecauxAPICall(urlContract, query).Result;
            List<Contract> allContracts = JsonSerializer.Deserialize<List<Contract>>(response);
            return allContracts;
        }
        public List<Station> getStationsForAContract(string contract)
        {
            string query = "apiKey=" + key + "&contract=" + contract;
            string response = JCDecauxAPICall(urlStation, query).Result;
            List<Station> allStations = JsonSerializer.Deserialize<List<Station>>(response);
            return allStations;
        }
        public Contract getContratForPosition(double latitude, double longitude)
        {
            List<Contract> contracts = getContracts();
            foreach (Contract c in contracts)
            {
                List<Station> stations = getStationsForAContract(c.name);
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
        public Station getClosestStationWithAvailableBikes(double latitude, double longitude)
        {
            GeoCoordinate stationCoordinates = new GeoCoordinate(latitude, longitude);
            Contract contrat = getContratForPosition(latitude, longitude);
            List<Station> allStations = getStationsForAContract(contrat.name);
            Double minDistance = -1;
            Station closestStation = null;
            foreach (Station item in allStations)
            {
                // Find the current station's position.
                GeoCoordinate candidatePos = new GeoCoordinate(item.position.latitude, item.position.longitude);
                // And compare its distance to the chosen one to see if it is closer than the current closest.
                Double distanceToCandidate = stationCoordinates.GetDistanceTo(candidatePos);

                if (distanceToCandidate != 0 && (minDistance == -1 || distanceToCandidate < minDistance) && item.totalStands.availabilities.bikes > 0)

                {
                    closestStation = item;
                    minDistance = distanceToCandidate;
                }
               
            }
            return closestStation;
        }

        public Station getClosestStation(double latitude, double longitude)
        {
            GeoCoordinate stationCoordinates = new GeoCoordinate(latitude, longitude);
            Contract contrat = getContratForPosition(latitude, longitude);
            List<Station> allStations = getStationsForAContract(contrat.name);
            Double minDistance = -1;
            Station closestStation = null;
            foreach (Station item in allStations)
            {
                // Find the current station's position.
                GeoCoordinate candidatePos = new GeoCoordinate(item.position.latitude, item.position.longitude);
                // And compare its distance to the chosen one to see if it is closer than the current closest.
                Double distanceToCandidate = stationCoordinates.GetDistanceTo(candidatePos);

                if (distanceToCandidate != 0 && (minDistance == -1 || distanceToCandidate < minDistance) )

                {
                    closestStation = item;
                    minDistance = distanceToCandidate;
                }

            }
            return closestStation;
        }

        public Station getClosestStationWithAvailableStands(double latitude, double longitude)
        {
            GeoCoordinate stationCoordinates = new GeoCoordinate(latitude, longitude);
            Contract contrat = getContratForPosition(latitude, longitude);
            List<Station> allStations = getStationsForAContract(contrat.name);
            Double minDistance = -1;
            Station closestStation = null;
            foreach (Station item in allStations)
            {
                // Find the current station's position.
                GeoCoordinate candidatePos = new GeoCoordinate(item.position.latitude, item.position.longitude);
                // And compare its distance to the chosen one to see if it is closer than the current closest.
                Double distanceToCandidate = stationCoordinates.GetDistanceTo(candidatePos);

                if (distanceToCandidate != 0 && (minDistance == -1 || distanceToCandidate < minDistance) && item.totalStands.availabilities.stands > 0)

                {
                    closestStation = item;
                    minDistance = distanceToCandidate;
                }

            }
            return closestStation;
        }
        public double getDistanceTo(double[] position,double[] destination)
        {
            GeoCoordinate stationCoordinates = new GeoCoordinate(position[0], position[1]);
            GeoCoordinate destinationCoordinates = new GeoCoordinate(destination[0], destination[1]);
            return stationCoordinates.GetDistanceTo(destinationCoordinates);
        }
    }
        
        

    }

