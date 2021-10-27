package endpoints;

import dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.testmessage.TestMessageDAO;
import dk.viabnb.api.v1.concept.GetConceptMessageRequest;
import dk.viabnb.api.v1.concept.GetConceptMessageResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

import java.sql.SQLException;

@Endpoint
public class ConceptMessageEndpoint
{
  private static final String NAMESPACE ="http://viabnb.dk/api/v1/concept";
  private TestMessageDAO messageDAO;

 @Autowired
  public ConceptMessageEndpoint(TestMessageDAO messageDAO)
  {
    this.messageDAO = messageDAO;
  }

  @PayloadRoot(namespace = NAMESPACE, localPart = "GetConceptMessageRequest")
  @ResponsePayload
  public GetConceptMessageResponse getConceptMessage(@RequestPayload GetConceptMessageRequest request){
    GetConceptMessageResponse response = new GetConceptMessageResponse();
    try
    {
      response.setConceptMessage(messageDAO.GetMessage(request.getId()));
      return response;
    }
    catch (SQLException e)
    {
      throw new IllegalStateException();
    }
  }

}
