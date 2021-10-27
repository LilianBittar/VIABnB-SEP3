package endpoints;

import dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.testmessage.TestMessageDAO;
import https.concept_test_com.v1.concept.GetConceptMessageRequest;
import https.concept_test_com.v1.concept.GetConceptMessageResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;

import java.sql.SQLException;

@Endpoint
public class ConceptMessageEndpoint
{
  private static final String NAMESPACE_URL ="https://concept-test.com/v1/concept";
  private TestMessageDAO messageDAO;

 @Autowired
  public ConceptMessageEndpoint(TestMessageDAO messageDAO)
  {
    this.messageDAO = messageDAO;
  }

  @PayloadRoot(namespace = NAMESPACE_URL, localPart = "getConceptMessageRequest")
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
