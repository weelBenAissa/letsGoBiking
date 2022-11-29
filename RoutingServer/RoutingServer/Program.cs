using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoutingServer
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            JcDeceaux jc = new JcDeceaux();
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
      
            Console.WriteLine("Choisir une station de départ");
            string depart = Console.ReadLine();
            //Console.WriteLine("Choisir une station d'arrivée");
            //string arrive = Console.ReadLine();
            //Console.WriteLine("Choisir un profil");
            //string profile = Console.ReadLine();
            //Service service = new Service();


        }
    }
}
