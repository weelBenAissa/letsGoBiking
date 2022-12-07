package com.soc.testwsclient;

import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;

import javax.jms.*;
import java.util.logging.Logger;
import javax.jms.JMSException;
import java.util.logging.Logger;

public class ActiveMQ {

    private static String url = ActiveMQConnection.DEFAULT_BROKER_URL;
    static Logger logger = Logger.getLogger(TestWSClient.class.getName());
    private static String s = "QueueLetsGoBiking";

    public static void activeMq2() throws JMSException {
        System.out.println("Received message");
        ConnectionFactory connectionFactory = new ActiveMQConnectionFactory(url);
        Connection connection = connectionFactory.createConnection();
        connection.start();

        Session session = connection.createSession(false,
                Session.AUTO_ACKNOWLEDGE);

        Destination destination = session.createQueue(s);

        MessageConsumer consumer = session.createConsumer(destination);
        System.out.println("Received message");


        Message message = consumer.receive(1000);


        System.out.println("Received message '" + message + "'");
        if (message instanceof TextMessage) {
            TextMessage textMessage = (TextMessage) message;
            System.out.println("Received message '" + textMessage.getText() + "'");
        }
        connection.close();



    }
    }