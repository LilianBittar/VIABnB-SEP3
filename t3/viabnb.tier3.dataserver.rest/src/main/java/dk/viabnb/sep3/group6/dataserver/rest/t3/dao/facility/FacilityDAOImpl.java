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
  @Override public Facility createResidenceFacility(Facility facility,
      int residenceId)
  {
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("INSERT INTO residencefacility(facilityid, residenceid) VALUES (?,?)");
      stm.setInt(1, facility.getId());
      stm.setInt(2, residenceId);
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
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public void deleteResidenceFacility(int facilityId, int residenceId)
  {
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("DELETE FROM residencefacility WHERE facilityid = ? AND residenceid = ?");
      stm.setInt(1, facilityId);
      stm.setInt(2, residenceId);
      stm.executeUpdate();
      connection.commit();
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
