using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingServer
{
    public class TotalStands
    {
        public Availabilities availabilities { get; set; }
    }
    public class Availabilities
    {
        public int bikes { get; set; }
        public int stands { get; set; }

    }
}
