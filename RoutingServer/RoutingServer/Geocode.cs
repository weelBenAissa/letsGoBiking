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
        public List<Feature> features { get; set; }

        public class Feature

        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public Geometry geometry { get; set; }
        }
    }
    public class Geometry
    {
        
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
    
    public class Properties
    {
        public string locality { get; set; }
        
    }
}
   
  



    
