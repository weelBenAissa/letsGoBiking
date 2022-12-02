using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading;
using static RoutingServer.Direction;

namespace RoutingServer
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            JcDeceaux jc = new JcDeceaux();
            OpenRoute opr = new OpenRoute();
            Service s = new Service();
            Console.WriteLine("Type a departure adress");
            string start = Console.ReadLine();
            Console.WriteLine("Type an arrival adress");
            string end = Console.ReadLine();
            s.GetItinerary(start, end);
            Console.ReadLine();
            /*
            Position depart = new Position( 49.41461, 8.681495); 
            Position arrive = new Position(49.420318,8.687872 );
            Feature feat = opr.getItineraryCyclingRegular(depart, arrive);
            for (int i = 0; i < feat.properties.segments[0].steps.Count; i++)
            {
                Console.WriteLine(feat.properties.segments[0].steps[i].instruction);
            }
            Console.ReadLine();

            */





        }

    }

    }
