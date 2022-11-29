using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Collections.Specialized.BitVector32;


namespace RoutingServer
{
  
    internal class Service : IService
    {
        private static HttpClient client = new HttpClient();
        private List<station> stations = new List<station>();
   
        string KEY = "5b3ce3597851110001cf624810d1e3dd14444e7890e65060cb520bac";
        string PATH = "https://api.openrouteservice.org";
       public Direction GetItinerary(Double depart, Double arrive,string profile)  
        {
            if (profile == null)
            {
                profile = "driving-car";
            }
            string url = PATH + "/v2/directions/" + profile + "?api_key=" + KEY;
            string json = "{\"coordinates\":[[" + depart + "],[" + arrive + "]],\"profile\":\"" + profile + "\",\"preference\":\"fastest\",\"format\":\"geojson\"}";
            HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
            return response.Content.ReadAsAsync<Direction>().GetAwaiter().GetResult();

        }

    }
    public class contract
    {
        string name { get; set; }
    }
    public class station
    {
        public int number { get; set; }
        public string name { get; set; }
        public Position position { get; set; }
    }
    public class Position
    {
        public Double latitude { get; set; }
        public Double longitude { get; set; }
    }

}
