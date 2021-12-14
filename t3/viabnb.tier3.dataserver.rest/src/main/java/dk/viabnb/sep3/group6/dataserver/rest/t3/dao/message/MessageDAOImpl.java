package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.message;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Message;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class MessageDAOImpl extends BaseDao implements MessageDAO
{
  @Override public Message createMessage(Message message)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "INSERT INTO message(senderid, receiverid, "
              + "messagecontent, timesent) values (?,?,?,?)");
      stm.setInt(1, message.getSender().getId());
      stm.setInt(2, message.getReceiver().getId());
      stm.setString(3, message.getContent());
      stm.setTimestamp(4, Timestamp.valueOf(message.getTimeSent()));
      stm.executeUpdate();
      connection.commit();
      return message;
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Message> getAllMessages()
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM message order by timesent asc");
      ResultSet result = stm.executeQuery();
      List<Message> messages = new ArrayList<>();
      while (result.next())
      {
        User sender = getUserById(result.getInt("senderid"));
        User receiver = getUserById(result.getInt("receiverid"));
        Message message = new Message(sender, receiver,
            result.getString("messagecontent"),
            result.getTimestamp("timesent").toLocalDateTime());
        messages.add(message);
      }
      return messages;

    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private User getUserById(int userId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user WHERE userid = ?");
      stm.setInt(1, userId);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new User(result.getInt("userid"), result.getString("email"),
            result.getString("password"), result.getString("fname"),
            result.getString("lname"), result.getString("phonenumber"),
            result.getString("personalimage"));
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
