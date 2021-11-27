package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;

import java.sql.*;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class RentRequestDAOImpl extends BaseDao implements RentRequestDAO
{

  @Override public RentRequest create(RentRequest request)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "insert into rentrequest(startdate, enddate, numberofguests, status, hostid) values (?,?,?,?,?)");
      stm.setDate(1, Date.valueOf(request.getStartDate().toString()));
      stm.setDate(2, Date.valueOf(request.getEndDate().toString()));
      stm.setInt(3, request.getNumberOfGuests());
      stm.setString(4, RentRequestStatus.NOTANSWERED.name());
      stm.setInt(5, request.getResidence().getHost().getId());
      stm.executeUpdate();
      connection.commit();
      return request;

    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public RentRequest update(RentRequest request)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "UPDATE rentrequest SET status = ?");
      stm.setString(1, request.getStatus().name());
      stm.executeUpdate();
      connection.commit();
      return request;
    }
    catch (SQLException throwables)
    {
      throw new IllegalArgumentException(throwables.getMessage());
    }
  }

  @Override public RentRequest getById(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM rentrequest JOIN host h ON h.hostid = rentrequest.hostid JOIN guest g ON h.hostid = g.guestid WHERE rentrequestid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new RentRequest(result.getInt("rentrequestid"),
            result.getDate("startdate").toLocalDate().atStartOfDay(),
            result.getDate("enddate").toLocalDate().atStartOfDay(),
            result.getInt("numberofhuests"),
            RentRequestStatus.valueOf(result.getString("rentrequeststatus")),
            new Guest(result.getInt("hostid"), result.getString("fname"),
                result.getString("lname"), result.getString("phonenumber"),
                result.getString("email"), result.getString("password"),
                new ArrayList<>(), result.getString("personalimage"),
                result.getString("cpr"), result.getBoolean("isapprovedhost"),
                result.getInt("viaid"), new ArrayList<>(),
                result.getBoolean("isapprovedguest")),
            getResidenceByHostId(id));
      }
      throw new IllegalArgumentException("Rent request is null");
    }
    catch (SQLException throwables)
    {
      throw new IllegalArgumentException(throwables.getMessage());
    }
  }

  @Override public List<RentRequest> getAll()
  {
    return null;
  }

  private Residence getResidenceByHostId(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM residence JOIN address a ON a.addressid = residence.addressid JOIN city c ON c.cityid = a.cityid WHERE hostid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        return new Residence(result.getInt("residenceid"),
            new Address(result.getInt("addressid"),
                result.getString("streetname"),
                result.getString("streetnumber"),
                result.getString("housenumber"),
                new City(result.getInt("cityid"), result.getString("cityname"),
                    result.getInt("zipcode"))), result.getString("description"),
            result.getString("type"), result.getBoolean("isavailable"),
            result.getDouble("pricepernight"), new ArrayList<>(),
            new ArrayList<>(), result.getString("imageurl"),
            result.getDate("availablefrom"), result.getDate("availableto"),
            result.getInt("maxnumberofguests"),
            new Host(result.getInt("hostid"), result.getString("fname"),
                result.getString("lname"), result.getString("phonenumber"),
                result.getString("email"), result.getString("password"),
                new ArrayList<>(), result.getString("personalimage"),
                result.getString("cpr"), result.getBoolean("isapprovedhost")),
            new ArrayList<>());
      }
      throw new IllegalArgumentException("residence is null");
    }
    catch (SQLException throwables)
    {
      throw new IllegalArgumentException(throwables.getMessage());
    }
  }
}
