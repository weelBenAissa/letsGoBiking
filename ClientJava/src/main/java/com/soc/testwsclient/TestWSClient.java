package com.soc.testwsclient;

import com.soap.ws.client.generated.ArrayOfDirectionStep;
import com.soap.ws.client.generated.IRoutingService;
import com.soap.ws.client.generated.RoutingService;
import javax.jms.JMSException;
import java.util.Scanner;


public class TestWSClient {
    public static void main(String[] args) throws InterruptedException {
        RoutingService routingservice=new RoutingService();
        IRoutingService irouting= routingservice.getBasicHttpBindingIRoutingService();
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter start point");
        String source = sc.nextLine();

        System.out.println("Enter end point");
        String destination = sc.nextLine();


        IRoutingService lgbItinerary;
        RoutingService service = new RoutingService();
        lgbItinerary = service.getBasicHttpBindingIRoutingService();

        ArrayOfDirectionStep responseJsonStr = lgbItinerary.getItinerary(source,destination);

        try {
            ActiveMQ.activeMq2();
        } catch (JMSException e) {
            e.printStackTrace();
        }


    }
}
