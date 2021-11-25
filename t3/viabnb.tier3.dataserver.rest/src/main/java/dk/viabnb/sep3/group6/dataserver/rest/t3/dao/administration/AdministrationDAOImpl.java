package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Administrator;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class AdministrationDAOImpl extends BaseDao implements AdministrationDAO
{
  private static final Logger LOGGER = LoggerFactory.getLogger(
      AdministrationDAO.class);

  @Override public Administrator getAdministratorByEmail(String email)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM admin WHERE email = ?");
      stm.setString(1, email);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new Administrator(result.getInt("adminid"),
            result.getString("fname"), result.getString("lname"),
            result.getString("email"), result.getString("phonenumber"),
            result.getString("password"));
      }
      throw new IllegalArgumentException("Admin is null");
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
