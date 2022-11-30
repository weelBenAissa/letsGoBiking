using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RoutingServer
{
    internal class OpenSreet
    {
        private string url = "https:// api.openrouteservice.org /v2/directions/";
        private string key = "5b3ce3597851110001cf624810d1e3dd14444e7890e65060cb520bac";
        static async Task<string> OSPMApiCall(string url, string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
