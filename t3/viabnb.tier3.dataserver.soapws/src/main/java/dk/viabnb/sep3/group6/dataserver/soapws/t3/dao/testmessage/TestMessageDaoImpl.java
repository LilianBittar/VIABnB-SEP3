package dk.viabnb.sep3.group6.dataserver.soapws.t3.dao.testmessage;

import dk.viabnb.sep3.group6.dataserver.soapws.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.soapws.t3.models.ConceptMessage;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.NoSuchElementException;
//import java.util.concurrent.locks.Lock;
//import java.util.concurrent.locks.ReentrantLock;

@Service
@Scope("singleton")
public class TestMessageDaoImpl extends BaseDao implements TestMessageDao
{


//  private static TestMessageDao instance;

  public TestMessageDaoImpl()
  {
  }

//  public static TestMessageDao getInstance()
//  {
//    if (instance ==  null)
//    {
//      synchronized (lock)
//      {
//        instance = new TestMessageDaoImpl();
//      }
//    }
//    return instance;
//  }

  @Override public ConceptMessage GetMessage(int msgId)
  {
    System.out.println("TestMessageDao called");
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          (
              "SELECT * FROM TestMessage WHERE id = ?"
          );
      stm.setInt(1, msgId);
      ResultSet result = stm.executeQuery();

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
    catch(Exception e)
    {
      e.printStackTrace();
    }
    return null;
  }
}
