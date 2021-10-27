package dk.viabnb.sep3.group6.dataserver.soapws.t3.endpoints;

import dk.viabnb.sep3.group6.dataserver.soapws.t3.SpringConfig;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

import javax.xml.ws.Endpoint;

public class ConceptMessagePublisher
{
  public static void main(String[] args)
  {
    AnnotationConfigApplicationContext applicationContext = new AnnotationConfigApplicationContext(
        SpringConfig.class);

    ConceptMessageService conceptMessageService = applicationContext.getBean("conceptMessageServiceImpl", ConceptMessageService.class);
    System.out.println(conceptMessageService);
    Endpoint.publish("http://localhost:8080/ws/conceptmessage", conceptMessageService);
  }
}
