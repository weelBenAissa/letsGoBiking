using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RoutingServer
{
    public class Geocode
    {

        [DataMember]
        public double longt { get; set; }
        [DataMember]
        public double latt { get; set; }
    }
   
   
}


    
