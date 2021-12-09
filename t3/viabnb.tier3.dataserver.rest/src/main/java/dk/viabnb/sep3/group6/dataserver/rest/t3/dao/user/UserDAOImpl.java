package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.user;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class UserDAOImpl extends BaseDao implements UserDAO
{
  private static final Logger LOGGER = LoggerFactory.getLogger(UserDAO.class);

  @Override public User getUserByEmail(String email)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user WHERE email = ?");
      stm.setString(1, email);
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

  @Override public User getUserById(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user WHERE userid = ?");
      stm.setInt(1, id);
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

  @Override public List<User> getAllUsers()
  {
    List<User> users = new ArrayList<>();
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user");
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        User user = new User(result.getInt("userid"), result.getString("email"),
            result.getString("password"), result.getString("fname"),
            result.getString("lname"), result.getString("phonenumber"),
            result.getString("personalimage"));
        users.add(user);
      }
      return users;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public User updateUser(User user)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "UPDATE _user SET fname = ?, lname = ?, email = ? , password = ?, phonenumber = ?, personalimage = ? WHERE userid = ?");
      stm.setString(1, user.getFirstName());
      stm.setString(2, user.getLastName());
      stm.setString(3, user.getEmail());
      stm.setString(4, user.getPassword());
      stm.setString(5, user.getPhoneNumber());
      stm.setString(6, user.getProfileImageUrl());
      stm.setInt(7, user.getId());
      stm.executeUpdate();
      connection.commit();
      return user;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public void deleteUser(int userid)
  {
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("DELETE FROM _user WHERE userid = ?");
      stm.setInt(1, userid);
      stm.executeUpdate();
      connection.commit();
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
