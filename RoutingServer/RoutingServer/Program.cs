using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static RoutingServer.Direction;

namespace RoutingServer
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            JcDeceaux jc = new JcDeceaux();
            OpenRoute opr = new OpenRoute();
           
            /*
            List<Contract> contracts = jc.GetContracts();
            Console.WriteLine("Contracts:");
            foreach (Contract c in contracts)
            {
                Console.WriteLine(c.name);
            }


            Console.WriteLine("Choisir un contrat");
            string contract = Console.ReadLine();
            List<Station> stations = jc.GetStationsForAContract(contract);
            Console.WriteLine("affichage des stations");
            foreach (Station s in stations)
            {
                Console.WriteLine(s.name);
                Console.WriteLine(s.number);
            }
      
            Console.WriteLine("Choisir une station de départ avec son chiffre");
            int stationNumber = Int32.Parse(Console.ReadLine().Split(new[] { ':' })[0]);
            Station chosenStation = stations[0];
            foreach (Station s in stations)
            {
                if (s.number == stationNumber)
                {
                    chosenStation = s;
                }
            }
            Station stationClose = jc.getClosestStationWithAvailableBikes(chosenStation.position.latitude, chosenStation.position.longitude);
            Console.WriteLine(stationClose.name);
            Console.WriteLine(stationClose.number);
            Console.WriteLine(stationClose.totalStands.availabilities.bikes);
            
            Console.WriteLine("Ecrire une addresse pour retrouver ses coordoonée");
            string adress = Console.ReadLine();
            double[] coor =  opr.getCoordinatesFromStrAddress(adress);
            Console.WriteLine("longitude:" + coor[0] );
            Console.WriteLine("lattitude:" + coor[1]);
            Console.WriteLine("Le contrat associé a cette position est: ");
            Contract c = jc.getContratForPosition(coor[1], coor[0]);
            Console.WriteLine(c.name);
            /*
            //Console.WriteLine("Choisir un profil");
            //string profile = Console.ReadLine();
            //Service service = new Service();

        */
            Console.WriteLine("Choisir une addresse pour retrouver sa ville et le contrat associé");
            string adress = Console.ReadLine();
            string city = opr.getCityFromStrAddress(adress);
            Contract c = opr.getContractFromStrAddress(adress);
            Console.WriteLine("la ville: "+city+" et le contrat associé est: "+c.name);
            Console.ReadLine();



        }
    }
}
