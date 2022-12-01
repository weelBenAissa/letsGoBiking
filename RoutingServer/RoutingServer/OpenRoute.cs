using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
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
        static async Task<string> OSPMApiCall(string url, string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
      
        public Direction getItineraryFootWalking(double depart,double arrive) {
            string profile = "foot-walking";
            string query = "api_key=" + key;
            string response = OSPMApiCall(url + profile, query).Result;
            Direction direction = JsonSerializer.Deserialize<Direction>(response);
            return direction;
        }
       public Direction getItineraryCyclingRegular(double depart,double arrive)
        {
            {
                string profile = "cycling-regular";
                string query = "api_key=" + key;
                string response = OSPMApiCall(url + profile, query).Result;
                Direction direction = JsonSerializer.Deserialize<Direction>(response);
                return direction;
            }
        }
        
        public List<Feature> getFeatureFromStrAddress(string address)
        {
           ;
            string query = "text="+ address +"&api_key=" + key; 
            string url = "https://api.openrouteservice.org/geocode/search"; 
            string response = OSPMApiCall(url , query).Result;
            JsonElement jsonFeatures = JsonDocument.Parse(response).RootElement.GetProperty("features");
            List<Feature> listFeatures = JsonSerializer.Deserialize<List<Feature>>(jsonFeatures);
            return listFeatures;
        }
        public string getCityFromStrAddress(string addr)
        {
            List<Feature> listFeatures = getFeatureFromStrAddress(addr);
            string city = listFeatures[0].properties.county;
            return city;
        }
        
        public double[] getCoordinatesFromStrAddress(string address)
        {
            Feature feature = getFeatureFromStrAddress(address)[0];
            double[] coordinates = new double[2];
            coordinates[0] = feature.geometry.coordinates[0];
            coordinates[1] = feature.geometry.coordinates[1];
            return coordinates;
        }
        /*public Direction getPath(double[] depart, double[] arrive)
        {
            
        }
        */




    }
}
