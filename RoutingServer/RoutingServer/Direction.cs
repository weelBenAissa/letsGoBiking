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
        public List<Feature> features { get; set; }

        [DataContract]
        public class Feature
        {
            [DataMember]
            public string type { get; set; }
            [DataMember]
            public Properties properties { get; set; }
            [DataMember]
            public Geometry geometry { get; set; }
        }
        [DataContract]
        public class Properties
        {
            [DataMember]
            public List<Segment> segments { get; set; }
            [DataMember]
            public Geometry geometry { get; set; }
            [DataMember]
            public Summary summary { get; set; }
            [DataMember]
            public string locality { get; set; }

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
            public List<List<double>> coordinates { get; set; }
            public string type { get; set; }

        }
       
    
        [DataContract]
        public class Segment
        {
            [DataMember]
            double distance { get; set; }
            [DataMember]
            double duration { get; set; }
            [DataMember]
            public List<Step> steps { get; set; }
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
            public string instruction { get; set; }
            [DataMember]
            string name { get; set; }
            [DataMember]
            List<int> way_points { get; set; }
            
        }


    }
    }
    

