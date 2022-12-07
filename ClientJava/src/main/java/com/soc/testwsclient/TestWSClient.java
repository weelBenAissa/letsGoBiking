package com.soc.testwsclient;

import com.soap.ws.client.generated.ArrayOfDirectionStep;
import com.soap.ws.client.generated.IRoutingService;
import com.soap.ws.client.generated.RoutingService;
import com.sun.xml.xsom.impl.scd.Step;

import java.util.List;
import java.util.Scanner;

import static java.lang.Thread.sleep;

public class TestWSClient {
    public static void main(String[] args) throws InterruptedException {
        RoutingService routingservice=new RoutingService();
        IRoutingService irouting= routingservice.getBasicHttpBindingIRoutingService();
        Scanner scanner = new Scanner(System.in);
        System.out.println("Hello World! we are going to test a SOAP client written in Java");
        System.out.println("Please type a departure address ");
        String departureAddress = scanner.nextLine();
        System.out.println("Please type a destination address ");
        String destinationAddress = scanner.nextLine();
//"114B Av. des Martyrs de la Résistance, 76100 Rouen"
// "1 Rue Albert Dupuis, 76044 Rouen"

        ArrayOfDirectionStep steps = irouting.getItinerary(departureAddress,destinationAddress);
        for(int i=0;i<steps.getDirectionStep().size();i++){
            System.out.println(steps.getDirectionStep().get(i).getInstruction().getValue());
            Thread.sleep(100);
        }
    }
}
