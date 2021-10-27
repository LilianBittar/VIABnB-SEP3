package dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.testmessage;

import dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao.BaseDao;
import dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.models.ConceptMessage;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.NoSuchElementException;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

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
        return new ConceptMessage(result.getInt("id"), result.getString("msg"));
      }
      else
      {
        throw new NoSuchElementException();
      }
    }
  }
}
