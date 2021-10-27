package dk.viabnb.sep3.group6.dataserver.soapws.t3.endpoints;

import dk.viabnb.sep3.group6.dataserver.soapws.t3.dao.testmessage.TestMessageDao;
import dk.viabnb.sep3.group6.dataserver.soapws.t3.models.ConceptMessage;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import javax.jws.WebService;
import java.util.NoSuchElementException;

@Component
@WebService(endpointInterface = "dk.viabnb.sep3.group6.dataserver.soapws.t3.endpoints.ConceptMessageService")
public class ConceptMessageServiceImpl implements ConceptMessageService
{
  private TestMessageDao testMessageDao;

  public ConceptMessageServiceImpl()
  {
  }

  @Autowired
  public void setTestMessageDao(TestMessageDao testMessageDao)
  {
    this.testMessageDao = testMessageDao;
  }

  @Override public ConceptMessage getConceptMessage(int id)
  {
    ConceptMessage conceptMessage = null;
    try
    {
     conceptMessage = testMessageDao.GetMessage(1);
    }
    catch (NoSuchElementException e)
    {
      e.printStackTrace();
    }

    return conceptMessage;
  }

}
