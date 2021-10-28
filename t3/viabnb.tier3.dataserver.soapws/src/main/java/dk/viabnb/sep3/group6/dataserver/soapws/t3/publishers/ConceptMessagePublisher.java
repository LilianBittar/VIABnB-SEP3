package dk.viabnb.sep3.group6.dataserver.soapws.t3.publishers;

import dk.viabnb.sep3.group6.dataserver.soapws.t3.SpringConfig;
import dk.viabnb.sep3.group6.dataserver.soapws.t3.endpoints.ConceptMessageService;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

import javax.xml.ws.Endpoint;

public class ConceptMessagePublisher
{
  public static void main(String[] args)
  {
    AnnotationConfigApplicationContext applicationContext = new AnnotationConfigApplicationContext(
        SpringConfig.class);

    final String ENDPOINT_ADDRESS = "http://localhost:8080/ws/conceptmessage";
    ConceptMessageService conceptMessageService = applicationContext.getBean(
        "conceptMessageServiceImpl", ConceptMessageService.class);
    System.out.println("Starting Data server endpoint on: " + ENDPOINT_ADDRESS +"\n"+"WSDL can be found on " + ENDPOINT_ADDRESS + "?wsdl" );
    Endpoint.publish(ENDPOINT_ADDRESS,
        conceptMessageService);

  }
}
