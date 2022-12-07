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
using ProxyCache;
using static ProxyCache.JCDeceaux;

namespace RoutingServer
{
    internal class JcDecaux
    {
        private string urlContract = "https://api.jcdecaux.com/vls/v3/contracts";
        private string key = "3d2ab2ea77d811391e1cea4265a75794bda2f0a9";
        private string urlStation = "https://api.jcdecaux.com/vls/v3/stations";
        public ProxyService proxy = new ProxyService();

        static async Task<string> JCDecauxAPICall(string url, string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        
        public List<Contract> getContracts()
        {
            return proxy.getContracts();
        }
        public List<Station> getStationsForAContract(string contract)
        {
            return proxy.getStationsByContract(contract);
        }
       
        public Station getClosestStationWithAvailableBikes(Position p,Contract contrat)
        {
            GeoCoordinate stationCoordinates = new GeoCoordinate(p.latitude, p.longitude);
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
       
        public Station getClosestStation(Position p,Contract contrat)
        {
            GeoCoordinate stationCoordinates = new GeoCoordinate(p.latitude, p.longitude);
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

        public Station getClosestStationWithAvailableStands(Position p,Contract contrat)
        {
            GeoCoordinate stationCoordinates = new GeoCoordinate(p.latitude, p.longitude);
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
        
    }
        
        

    }

