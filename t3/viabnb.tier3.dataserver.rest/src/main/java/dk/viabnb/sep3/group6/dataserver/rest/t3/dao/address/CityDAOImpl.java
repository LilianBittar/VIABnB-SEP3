package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class CityDAOImpl extends BaseDao implements CityDAO
{
  @Override public City getCityById(int id)
  {
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("SELECT * FROM city WHERE cityid = ?");
      stm.setInt(1, id);

      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new City
            (
                result.getInt("cityId"),
                result.getString("cityname"),
                result.getInt("zipcode")
            );
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
