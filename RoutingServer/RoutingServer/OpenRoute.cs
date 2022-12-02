using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using static RoutingServer.Direction;

namespace RoutingServer
{
    internal class OpenRoute
    {
        private string url = "https://api.openrouteservice.org/v2/directions/";
        private string key = "5b3ce3597851110001cf624810d1e3dd14444e7890e65060cb520bac";
        private JcDeceaux jc = new JcDeceaux();
        static async Task<string> OSPMApiCall(string url, string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public Feature getItineraryFootWalking(Position depart, Position arrive)
        {
            {
                string starting = depart.longitude.ToString().Replace(',', '.') + "," + depart.latitude.ToString().Replace(',', '.');
                string ending = arrive.longitude.ToString().Replace(',', '.') + "," + arrive.latitude.ToString().Replace(',', '.');
                string profile = "foot-walking";
                string query = "api_key=" + key + "&start=" + starting + "&end=" + ending;
                string response = OSPMApiCall(url + profile, query).Result;
                JsonElement direction = JsonDocument.Parse(response).RootElement.GetProperty("features")[0];
                Feature feat = JsonSerializer.Deserialize<Feature>(direction);
                return feat;

            }
        }

        public Feature getItineraryCyclingRegular(Position depart,Position arrive)
        {
            {
                string starting = depart.longitude.ToString().Replace(',', '.') + "," + depart.latitude.ToString().Replace(',', '.');
                string ending = arrive.longitude.ToString().Replace(',', '.') + "," + arrive.latitude.ToString().Replace(',', '.');
                string profile = "cycling-regular";
                string query = "api_key=" + key + "&start="+starting+"&end="+ending;
                string response = OSPMApiCall(url + profile, query).Result;
                JsonElement direction = JsonDocument.Parse(response).RootElement.GetProperty("features")[0];
                Feature feat = JsonSerializer.Deserialize<Feature>(direction);
                return feat;
                
            }
        }
        
        public List<Geocode.Feature> getFeatureFromStrAddress(string address)
        {
           ;
            string query = "text="+ address +"&api_key=" + key; 
            string url = "https://api.openrouteservice.org/geocode/search"; 
            string response = OSPMApiCall(url , query).Result;
            JsonElement jsonFeatures = JsonDocument.Parse(response).RootElement.GetProperty("features");
            List<Geocode.Feature> listFeatures = JsonSerializer.Deserialize<List<Geocode.Feature>>(jsonFeatures);
            return listFeatures;
        }
        public string getCityFromStrAddress(string addr)
        {
            List<Geocode.Feature> listFeatures = getFeatureFromStrAddress(addr);
            string city = listFeatures[0].properties.locality;
            return city;
        }
        
        public List<Step> StepsForTheBestPath(string depart,string arrive)
        {
            List<Step> steps = new List<Step>();
            Contract contract = getContractFromStrAddress(depart);
            if (contract == null)
            {
                Console.WriteLine("Il n'y a pas de contrat associé a cette addresse");
                return null;
            }
            Position Pdepart = getPositionFromStrAddress(depart);
            Position Parrive = getPositionFromStrAddress(arrive);
            double durationAvelo;
            double durationApied;
            Station statProcheAvecVeloDispo = jc.getClosestStationWithAvailableBikes(Pdepart, contract);
            Position PdepartAvecVelo = statProcheAvecVeloDispo.position;
            Station statProcheAvecEmplacementDispo = jc.getClosestStationWithAvailableStands(Parrive, contract);
            Position ParriveAvecVelo = statProcheAvecEmplacementDispo.position;
            Feature featureAvelo = getItineraryCyclingRegular(PdepartAvecVelo, ParriveAvecVelo);
            Feature featureApied2 = getItineraryFootWalking(ParriveAvecVelo, Parrive);
            Feature featureApiedTotal = getItineraryFootWalking(Pdepart, Parrive);
            Feature featureApied1 = getItineraryFootWalking(Pdepart, PdepartAvecVelo);
            durationApied = featureApiedTotal.properties.summary.duration;
            double duration1 = featureApied1.properties.summary.duration;
            double duration2 = featureAvelo.properties.summary.duration;
            double duration3 = featureApied2.properties.summary.duration;
            durationAvelo = duration1 + duration2 + duration3;
            int tMarche1 = getItineraryFootWalking(Pdepart, PdepartAvecVelo).properties.segments[0].steps.Count;
            int tVelo = getItineraryCyclingRegular(PdepartAvecVelo, ParriveAvecVelo).properties.segments[0].steps.Count;
            int tMarche2 = getItineraryFootWalking(ParriveAvecVelo, Parrive).properties.segments[0].steps.Count;
            if (durationAvelo < durationApied)
            {
                steps.Add(new Step("Take a bike at " + statProcheAvecVeloDispo.name +" Duration : " + duration1 + " After: "));
                for(int i = 0; i < tMarche1; i++)
                {
                    steps.Add(featureApied1.properties.segments[0].steps[i]);
                }
                steps.Add(new Step("Ride to " + statProcheAvecEmplacementDispo.name + " Duration: " + duration2));
                for(int i = 0; i< tVelo; i++) {
                    steps.Add(featureAvelo.properties.segments[0].steps[i]);
                }
                steps.Add(new Step("Finally walk to your destination Duration: "+ duration3));
                for(int i = 0; i < tMarche2; i++)
                {
                    steps.Add(featureApied2.properties.segments[0].steps[i]);
                }
            }
            else
            {
                Console.WriteLine("Walk to your destination : ");
                steps = featureApiedTotal.properties.segments[0].steps;
                
            }
            return steps;

        }
        public void printStepsInstruction(List<Step> steps)
        {
            for(int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine(steps[i].instruction);
                Thread.Sleep(100);
            }
        }
        public Contract getContractFromStrAddress(string addr)
        {
            List<Contract> contracts = jc.getContracts();
            string cityAddr = getCityFromStrAddress(addr);
            foreach (Contract c in contracts)
            {
                for(int i = 0; i< c.cities.Length; i++) { if (c.cities[i] == cityAddr) ;
                    return c;
                }
                    
            }
            return null;
        }
        public Position getPositionFromStrAddress(string address)
        {
            Geocode.Feature feature = getFeatureFromStrAddress(address)[0];
            Position position = new Position(feature.geometry.coordinates[1], feature.geometry.coordinates[0]);
            return position;
        }
        




    }
}
