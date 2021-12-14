package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.host;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class HostDAOImpl extends BaseDao implements HostDAO
{
  @Override public Host registerHost(Host host)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm1 = connection.prepareStatement(
          "insert into _user(fname, lname, email, phonenumber,"
              + " password, personalimage) values (?,?,?,?,?,?)",
          PreparedStatement.RETURN_GENERATED_KEYS);
      PreparedStatement stm2 = connection.prepareStatement(
          "insert into host(hostid, cprnumber, isapproved ) "
              + "values (?,?,?)");
      //insert into user
      stm1.setString(1, host.getFirstName());
      stm1.setString(2, host.getLastName());
      stm1.setString(3, host.getEmail());
      stm1.setString(4, host.getPhoneNumber());
      stm1.setString(5, host.getPassword());
      stm1.setString(6, host.getProfileImageUrl());
      stm1.executeUpdate();
      ResultSet resultSet = stm1.getGeneratedKeys();
      resultSet.next();
      connection.commit();
      //insert into host
      stm2.setInt(1, resultSet.getInt(1));
      stm2.setString(2, host.getCpr());
      stm2.setBoolean(3, host.isApprovedHost());

      stm2.executeUpdate();
      connection.commit();
      return host;

    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Host getHostByEmail(String email)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN host h ON _user.userid = h"
              + ".hostid WHERE email = ?");
      stm.setString(1, email);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {

        List<HostReview> hostReviews = getHostReviewsByHostId(
            result.getInt("userid"));
        return new Host(result.getInt("userid"), result.getString("email"),
            result.getString("password"), result.getString("fname"),
            result.getString("lname"), result.getString("phonenumber"),
            result.getString("personalimage"), hostReviews,
            result.getString("cprnumber"), result.getBoolean("isapproved"));
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Host getHostById(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN host h ON _user.userid = h"
              + ".hostid where userid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        List<HostReview> hostReviews = getHostReviewsByHostId(
            result.getInt("hostid"));
        return new Host(result.getInt("userid"), result.getString("email"),
            result.getString("password"), result.getString("fname"),
            result.getString("lname"), result.getString("phonenumber"),
            result.getString("personalimage"), hostReviews,
            result.getString("cprnumber"), result.getBoolean("isapproved"));
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }

  }

  @Override public List<Host> getAllNotApprovedHosts()
  {
    List<Host> hostsToReturn = new ArrayList<>();
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN host h ON _user.userid = h.hostid WHERE h.isapproved = ?");
      stm.setBoolean(1, false);
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        List<HostReview> hostReviews = getHostReviewsByHostId(
            result.getInt("hostid"));
        Host hostToAdd = new Host(result.getInt("userid"),
            result.getString("email"), result.getString("password"),
            result.getString("fname"), result.getString("lname"),
            result.getString("phonenumber"), result.getString("personalimage"),
            hostReviews, result.getString("cprnumber"),
            result.getBoolean("isapproved"));
        hostsToReturn.add(hostToAdd);
      }
      return hostsToReturn;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Host approveHost(Host host)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "UPDATE host SET isapproved = true WHERE hostid = ?");
      stm.setInt(1, host.getId());
      stm.executeUpdate();
      connection.commit();
      return host;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Host rejectHost(Host host)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "DELETE FROM _user WHERE userid = ?");
      stm.setInt(1, host.getId());
      stm.executeUpdate();
      connection.commit();
      return host;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private List<HostReview> getHostReviewsByHostId(int hostId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM hostreview where hostid = ?");
      stm.setInt(1, hostId);
      ResultSet result = stm.executeQuery();
      List<HostReview> hostReviews = new ArrayList<>();
      while (result.next())
      {
        HostReview review = new HostReview(result.getInt("hostrating"),
            result.getString("hostreviewtext"), result.getInt("guestid"),
            result.getDate("createddate").toLocalDate(),
            result.getInt("hostid"));
        hostReviews.add(review);
      }
      return hostReviews;
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
