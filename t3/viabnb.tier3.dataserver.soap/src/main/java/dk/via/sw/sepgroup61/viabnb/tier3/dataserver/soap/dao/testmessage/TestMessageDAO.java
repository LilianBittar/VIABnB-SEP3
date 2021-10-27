package dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.testmessage;

import https.concept_test_com.v1.concept.ConceptMessage;

import java.sql.SQLException;

public interface TestMessageDAO
{
  ConceptMessage GetMessage(int msgId) throws SQLException;

}
