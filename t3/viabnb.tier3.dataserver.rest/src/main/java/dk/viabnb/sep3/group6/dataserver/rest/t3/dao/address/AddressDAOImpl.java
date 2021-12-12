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
  private CityDAO cityDAO = new CityDAOImpl();

  @Override public Address creteNewAddress(Address address)
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

  @Override public List<Address> getAll()
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
            new City(cityDAO.getCityById(result.getInt("cityid")).getCityId(),
                cityDAO.getCityById(result.getInt("cityid")).getCityName(),
                cityDAO.getCityById(result.getInt("cityid")).getZipCode()));
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
}
