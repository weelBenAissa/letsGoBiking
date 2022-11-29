using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RoutingServer
{
    [DataContract] 
   internal class Direction
    {
        [DataContract]
        public class features
        {
            [DataMember]
            public string type { get; set; }
            [DataMember]
            public Properties properties { get; set; }
            [DataMember]
            public string geometry { get; set; }
        }
        [DataContract]
        public class Properties
        {
            [DataMember]
            Segment segments { get; set; }
            [DataMember]
            Geometry geometry { get; set; }
            [DataMember]
            Summary summary { get; set; }

        }
        [DataContract]
        public class Summary {
            [DataMember]
            public double distance { get; set; }
            [DataMember]
            public double duration { get; set; }
        }
        [DataContract]
        public class Geometry
        {
            [DataMember]
            List<double> coordinates { get; set; }
        }
        [DataContract]
        public class Segment
        {
            [DataMember]
            double distance { get; set; }
            [DataMember]
            double duration { get; set; }
            [DataMember]
            List<Step> steps { get; set; }
        }
        public class Step
        {
            [DataMember]
            double distance { get; set; }
            [DataMember]
            double duration { get; set; }
            [DataMember]
            string type { get; set; }
            [DataMember]
            string instruction { get; set; }
            [DataMember]
            string name { get; set; }
            [DataMember]
            List<int> way_points { get; set; }
            
        }


    }
    }
    

