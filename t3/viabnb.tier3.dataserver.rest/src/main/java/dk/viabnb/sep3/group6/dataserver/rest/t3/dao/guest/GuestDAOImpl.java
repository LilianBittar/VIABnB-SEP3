package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class GuestDAOImpl extends BaseDao implements GuestDAO
{
  private static final Logger LOGGER = LoggerFactory.getLogger(GuestDAO.class);

  @Override public Guest createGuest(Guest guest)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "insert into guest(guestid, viaid, isapprovedguest) VALUES (?, ? ,false)");
      stm.setInt(1, guest.getId());
      stm.setInt(2, guest.getViaId());
      stm.executeUpdate();
      connection.commit();
      LOGGER.info("executed update: createGuest");
      return getGuestByUserId(guest.getId());

    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Guest> getAllGuests()
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN host h ON _user.userid = h.hostid JOIN guest g ON h.hostid = g.guestid");
      ResultSet result = stm.executeQuery();
      List<Guest> allGuests = new ArrayList<>();
      while (result.next())
      {
        List<GuestReview> guestReview = getGuestReviewsByGuestId(
            result.getInt("userid"));
        List<HostReview> hostReviews = getHostReviewsByHostId(
            result.getInt("userid"));
        Guest existingGuest = new Guest(result.getInt("userid"),
            result.getString("email"), result.getString("password"),
            result.getString("fname"), result.getString("lname"),
            result.getString("phonenumber"), result.getString("personalimage"),
            hostReviews, result.getString("cprnumber"),
            result.getBoolean("isapproved"), result.getInt("viaid"),
            guestReview, result.getBoolean("isapprovedguest"));
        allGuests.add(existingGuest);
      }
      return allGuests;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Guest getGuestByUserId(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN host h ON _user.userid = h.hostid JOIN guest g ON h.hostid = g.guestid "
              + "WHERE userid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        List<GuestReview> guestReview = getGuestReviewsByGuestId(id);
        List<HostReview> hostReviews = getHostReviewsByHostId(id);
        return new Guest(result.getInt("userid"), result.getString("email"),
            result.getString("password"), result.getString("fname"),
            result.getString("lname"), result.getString("phonenumber"),
            result.getString("personalimage"), hostReviews,
            result.getString("cprnumber"), result.getBoolean("isapproved"),
            result.getInt("viaid"), guestReview,
            result.getBoolean("isapprovedguest"));
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Guest> getAllNotApprovedGuests()
  {
    List<Guest> guestsToReturn = new ArrayList<>();
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          ("SELECT * FROM _user JOIN host h ON _user.userid = h.hostid JOIN guest g ON h.hostid = g.guestid"
              + " WHERE isapprovedguest = ?"));
      stm.setBoolean(1, false);
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        List<GuestReview> guestReview = getGuestReviewsByGuestId(
            result.getInt("userid"));
        List<HostReview> hostReviews = getHostReviewsByHostId(
            result.getInt("userid"));
        Guest guestToAdd = new Guest(result.getInt("userid"),
            result.getString("email"), result.getString("password"),
            result.getString("fname"), result.getString("lname"),
            result.getString("phonenumber"), result.getString("personalimage"),
            hostReviews, result.getString("cprnumber"),
            result.getBoolean("isapproved"), result.getInt("viaid"),
            guestReview, result.getBoolean("isapprovedguest"));
        guestsToReturn.add(guestToAdd);
      }
      return guestsToReturn;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Guest approveGuest(Guest guest)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "UPDATE guest SET isapprovedguest = true WHERE guestid = ?");
      stm.setInt(1, guest.getId());
      stm.executeUpdate();
      connection.commit();
      return guest;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Guest rejectGuest(Guest guest)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "DELETE FROM guest WHERE guestid = ?");
      stm.setInt(1, guest.getId());
      stm.executeUpdate();
      connection.commit();
      return guest;
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

  private List<GuestReview> getGuestReviewsByGuestId(int guestId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM guestreview  where guestid = ?");
      stm.setInt(1, guestId);
      ResultSet result = stm.executeQuery();
      List<GuestReview> guestReviews = new ArrayList<>();
      while (result.next())
      {
        GuestReview review = new GuestReview(result.getInt("guestrating"),
            result.getString("guestreviewtext"),
            result.getDate("createddate").toLocalDate(),
            result.getInt("guestid"), result.getInt("hostid"));
        guestReviews.add(review);
      }
      return guestReviews;
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
