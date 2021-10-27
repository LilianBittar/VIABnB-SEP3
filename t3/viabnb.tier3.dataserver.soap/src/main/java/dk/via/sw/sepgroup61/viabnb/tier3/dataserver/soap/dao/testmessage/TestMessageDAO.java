package dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.testmessage;

import dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.models.ConceptMessage;

import java.sql.SQLException;

public interface TestMessageDAO
{
  ConceptMessage GetMessage(int msgId) throws SQLException;

}
