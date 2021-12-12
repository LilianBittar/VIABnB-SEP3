package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Administrator;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class AdministrationDAOImpl extends BaseDao implements AdministrationDAO
{
  private static final Logger LOGGER = LoggerFactory.getLogger(
      AdministrationDAO.class);

  @Override public Administrator getAdministratorByEmail(String email)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN admin a ON _user.userid = a"
              + ".adminid WHERE email = ?");
      stm.setString(1, email);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new Administrator(result.getInt("userid"),
            result.getString("email"), result.getString("password"),
            result.getString("fname"), result.getString("lname"),
            result.getString("phonenumber"), result.getString("personalimage"),
            result.getString("initials"));
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Administrator> getAllAdministrators()
  {
    List<Administrator> administratorListToReturn = new ArrayList<>();
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN admin a ON _user.userid = a" + ".adminid");
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        Administrator administrator = new Administrator(result.getInt("userid"),
            result.getString("email"), result.getString("password"),
            result.getString("fname"), result.getString("lname"),
            result.getString("phonenumber"), result.getString("personalimage"),
            result.getString("initials"));
        administratorListToReturn.add(administrator);
      }
      return administratorListToReturn;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
