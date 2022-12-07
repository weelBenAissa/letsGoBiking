using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ProxyCache.JCDeceaux;

namespace ProxyCache
{

    public class ProxyService : IProxy
    {

        string key = "3d2ab2ea77d811391e1cea4265a75794bda2f0a9";
        string urlContract = "https://api.jcdecaux.com/vls/v3/contracts/";
        string urlStation = "https://api.jcdecaux.com/vls/v3/stations/";
        Cache<List<Contract>> cacheContract = new Cache<List<Contract>>();
        Cache<List<Station>> stationsCache = new Cache<List<Station>>();
        static async Task<string> JCDecauxAPICall(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public List<Contract> getContracts()
        {

            List<Contract> contracts = cacheContract.Get("contracts");
            if (contracts != null)
            {
                
                return contracts;
            }
            else
            {
                
                string response = JCDecauxAPICall(urlContract + "?" + "apiKey=" + key).Result;
                contracts = JsonSerializer.Deserialize<List<Contract>>(response);
                cacheContract.Set("contracts", contracts, 1000);
            }
            return contracts;
        }





        public List<Station> getStationsByContract(string contract)
        {

            List<Station> stations = stationsCache.Get(contract);
            if (stations != null)
            {
               
                return stations;
            }
            else
            {
                string response = JCDecauxAPICall(urlStation + "?" + "apiKey=" + key + "&contract=" + contract).Result;
                stations = JsonSerializer.Deserialize<List<Station>>(response);
                stationsCache.Set(contract, stations, 1000);

            }
            return stations;

        }
    }
    

}
