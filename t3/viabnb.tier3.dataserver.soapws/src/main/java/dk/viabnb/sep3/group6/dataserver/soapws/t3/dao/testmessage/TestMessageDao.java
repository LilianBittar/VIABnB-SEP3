package dk.viabnb.sep3.group6.dataserver.soapws.t3.dao.testmessage;

import dk.viabnb.sep3.group6.dataserver.soapws.t3.models.ConceptMessage;

public interface TestMessageDao
{
  ConceptMessage GetMessage(int msgId);
}
