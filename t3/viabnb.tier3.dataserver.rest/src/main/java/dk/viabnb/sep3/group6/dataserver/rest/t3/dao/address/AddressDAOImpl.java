package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry.CityDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry.CityDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class AddressDAOImpl extends BaseDao implements AddressDAO
{
  private CityDAO cityDAO = new CityDAOImpl();

  @Override public Address getAddressById(int addressId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM address JOIN city c ON c.cityid = address.cityid WHERE addressid = ?");
      stm.setInt(1, addressId);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new Address(result.getInt("addressid"),
            result.getString("streetname"), result.getString("housenumber"),
            result.getString("streetnumber"),
            new City(cityDAO.getCityById(result.getInt("cityid")).getCityId(),
                cityDAO.getCityById(result.getInt("cityid")).getCityName(),
                cityDAO.getCityById(result.getInt("cityid")).getZipCode()));
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Address creteNewAddress(Address address)
  {
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("INSERT INTO address(streetname, streetnumber, housenumber, cityid) VALUES (?,?,?,?)");
      stm.setString(1, address.getStreetName());
      stm.setString(2, address.getStreetNumber());
      stm.setString(3, address.getHouseNumber());
      stm.setInt(4, address.getCity().getCityId());
      stm.executeUpdate();
      connection.commit();
      return address;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
