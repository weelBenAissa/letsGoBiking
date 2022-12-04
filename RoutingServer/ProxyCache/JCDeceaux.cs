using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCache
{
    internal class JCDeceaux
    {
        [DataContract]
        public class Contract
        {
            [DataMember]
            public string? name { get; set; }
            [DataMember]
            public int? number { get; set; }
            [DataMember]
            public string[]? cities { get; set; }
        }
        [DataContract]
        public class Station
        {
            [DataMember]
            public int? number { get; set; }
            [DataMember]
            public string? name { get; set; }
            [DataMember]
            public Position? position { get; set; }
            [DataMember]
            public TotalStands? totalStands { get; set; }
        }
        public class Position
        {
            [DataMember]
            public Double latitude { get; set; }
            [DataMember]
            public Double longitude { get; set; }
            public Position(double lat, double lon)
            {
                latitude = lat;
                longitude = lon;
            }
            public Position() { }

        }
        [DataContract]
        public class TotalStands
        {
            [DataMember]
            public Availabilities? availabilities { get; set; }
        }
        [DataContract]
        public class Availabilities
        {
            [DataMember]
            public int bikes { get; set; }
            [DataMember]
            public int stands { get; set; }

        }
    }
    

}
