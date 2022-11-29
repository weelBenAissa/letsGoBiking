using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Collections.Specialized.BitVector32;


namespace RoutingServer
{
    [ServiceContract]
    internal class Service : IService
    {
        private static HttpClient client = new HttpClient();
        private List<Station> stations = new List<Station>();
   
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
  

}
