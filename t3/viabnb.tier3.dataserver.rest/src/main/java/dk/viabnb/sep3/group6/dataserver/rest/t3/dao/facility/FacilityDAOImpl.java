package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Facility;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class FacilityDAOImpl extends BaseDao implements FacilityDAO
{
  @Override public Facility createFacility(Facility facility)
  {
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("INSERT INTO facility(name) VALUES (?)");
      stm.setString(1, facility.getName());
      stm.executeUpdate();
      connection.commit();
      return facility;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Facility> getAllFacilities()
  {
    List<Facility> facilityListToReturn = new ArrayList<>();
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("SELECT * FROM facility");
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        Facility facility = new Facility
            (
                result.getInt("facilityid"),
                result.getString("name")
            );
        facilityListToReturn.add(facility);
      }
      return facilityListToReturn;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Facility getFacilityById(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM facility WHERE facilityid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new Facility(result.getInt("facilityid"),
            result.getString("name"));
      }
      throw new IllegalArgumentException("Facility cant be null");
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
