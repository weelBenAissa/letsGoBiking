using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Collections.Specialized.BitVector32;
using static RoutingServer.Direction;

namespace RoutingServer
{
    
    internal class Service : IService
    {
        private JcDeceaux jc = new JcDeceaux();
        private OpenRoute op = new OpenRoute();
       

        public void GetItinerary(string start, string end)
        {
            List<Step> steps = op.StepsForTheBestPath(start, end);
            op.printStepsInstruction(steps);
        }
    }


}
