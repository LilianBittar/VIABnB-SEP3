package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry.CityDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry.CityDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class AddressDAOImpl extends BaseDao implements AddressDAO
{
  @Override public Address createNewAddress(Address address)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "INSERT INTO address(streetname, streetnumber, housenumber, cityid) VALUES (?,?,?,?)",
          Statement.RETURN_GENERATED_KEYS);
      stm.setString(1, address.getStreetName());
      stm.setString(2, address.getStreetNumber());
      stm.setString(3, address.getHouseNumber());
      stm.setInt(4, address.getCity().getCityId());
      stm.executeUpdate();
      ResultSet keys = stm.getGeneratedKeys();
      keys.next();
      connection.commit();
      address.setId(keys.getInt(1));
      return address;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Address> getAllAddress()
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM address JOIN city c ON c.cityid = "
              + "address.cityid");
      ResultSet result = stm.executeQuery();
      List<Address> addresses = new ArrayList<>();
      while (result.next())
      {
        Address address = new Address(result.getInt("addressid"),
            result.getString("streetname"), result.getString("housenumber"),
            result.getString("streetnumber"),
            new City(getCityById(result.getInt("cityid")).getCityId(),
                getCityById(result.getInt("cityid")).getCityName(),
                getCityById(result.getInt("cityid")).getZipCode()));
        addresses.add(address);
      }
      return addresses;
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private City getCityById(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM city WHERE cityid = ?");
      stm.setInt(1, id);

      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new City(result.getInt("cityId"), result.getString("cityname"),
            result.getInt("zipcode"));
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
