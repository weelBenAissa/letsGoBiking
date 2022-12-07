using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS.ActiveMQ;
using Apache.NMS;
using static RoutingServer.Direction;

namespace RoutingServer
{
    public class ActiveMq
    {
        private static ActiveMq instance;
        public static ActiveMq getInstance()
        {
            if (instance == null)
            {
                instance = new ActiveMq();
            }
            return instance;
        }

        public void send(string message)
        {
            Uri connecturi = new Uri("activemq:tcp://localhost:61616");
            ConnectionFactory connectionFactory = new ConnectionFactory(connecturi);

            // Create a single Connection from the Connection Factory.
            IConnection connection = connectionFactory.CreateConnection();
            connection.Start();

            // Create a session from the Connection.
            ISession session = connection.CreateSession();

            // Use the session to target a queue.
            IDestination destination = session.GetQueue("QueueLetsGoBiking");

            // Create a Producer targetting the selected queue.
            IMessageProducer producer = session.CreateProducer(destination);

            RoutingService s1 = new RoutingService();
            

            ITextMessage msg = session.CreateTextMessage(message);
            producer.Send(msg);








            Console.WriteLine("Message sent, check ActiveMQ web interface to confirm.");


            // Don't forget to close your session and connection when finished.
            session.Close();
            connection.Close();






        }

        public void send(List<Step> steps)
        {
            String message1 = "";
            foreach (Step s in steps)
            {
                message1 = message1 + "\n" + s.instruction.ToString();
            }
            send(message1);
        }
        
    }
    
}
