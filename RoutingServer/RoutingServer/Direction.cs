using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RoutingServer
{
    [DataContract]
    public class Direction
    {
        [DataMember]
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
            [DataMember]
            public string type { get; set; }

        }
       
    
        [DataContract]
        public class Segment
        {
            [DataMemberAttribute]
            double distance { get; set; }
            [DataMemberAttribute]
            double duration { get; set; }
            [DataMemberAttribute]
            public List<Step> steps { get; set; }
        }
        
        [DataContract]
        public class Step
        {
            [DataMemberAttribute]
            public string instruction { get; set; }
            public Step() { }
            
            public Step(string i)
            {
                instruction = i;


            }




        }

    }
    }
    

