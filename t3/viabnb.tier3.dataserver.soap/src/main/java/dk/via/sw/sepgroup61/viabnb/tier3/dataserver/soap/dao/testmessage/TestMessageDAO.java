package dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.testmessage;

import dk.viabnb.api.v1.concept.ConceptMessage;

import java.sql.SQLException;

public interface TestMessageDAO
{
  ConceptMessage GetMessage(int msgId) throws SQLException;

}
