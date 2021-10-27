package dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.testmessage;

import dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.BaseDao;
import dk.viabnb.api.v1.concept.ConceptMessage;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.NoSuchElementException;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

@Service
public class TestMessageDAOImpl extends BaseDao implements TestMessageDAO
{

  private static TestMessageDAO instance;
  private static final Lock lock = new ReentrantLock();

  private TestMessageDAOImpl()
  {
  }

  public static TestMessageDAO getInstance()
  {
    if (instance ==  null)
    {
      synchronized (lock)
      {
        instance = new TestMessageDAOImpl();
      }
    }
    return instance;
  }

  @Override public ConceptMessage GetMessage(int msgId) throws SQLException
  {
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
        (
            "SELECT * FROM TestMessage WHERE id = ?"
        );
      stm.setInt(1, msgId);
      ResultSet result = stm.executeQuery();;

      if (result.next())
      {
        ConceptMessage conceptMessage = new ConceptMessage();
        conceptMessage.setMessage(result.getString("msg"));
        conceptMessage.setId(result.getInt("id"));
        return conceptMessage;
      }
      else
      {
        throw new NoSuchElementException();
      }
    }
  }
}
