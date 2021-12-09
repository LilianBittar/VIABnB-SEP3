package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl.HostDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;


//the host review the guest and creates the guest review
public class GuestReviewDAOImpl extends BaseDao implements GuestReviewDAO
{
  private static final Logger LOGGER = LoggerFactory.getLogger(GuestReviewDAO.class);
  private HostDAO hostDAO = new HostDAOImpl();
  @Override public GuestReview createGuestReview(GuestReview guestReview)
  {
    try (Connection connection = getConnection()) {
      PreparedStatement stm = connection.prepareStatement(
              "INSERT INTO guestreview(guestrating, guestreviewtext, hostid, guestid, createddate) VALUES(?,?,?,?,?)");
      stm.setDouble(1, guestReview.getRating());
      stm.setString(2, guestReview.getText());
      stm.setInt(3, guestReview.getHostId());
      stm.setInt(4, guestReview.getGuestId());
      stm.setDate(5, (Date.valueOf(guestReview.getCreatedDate())));
      stm.executeUpdate();
      connection.commit();
      return guestReview;
    } catch (SQLException throwables) {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public GuestReview updateGuestReview(GuestReview guestReview)
  {
    try (Connection connection = getConnection()) {
      PreparedStatement stm = connection.prepareStatement("UPDATE guestreview " +
              "SET guestrating = ?, guestreviewtext = ?, createddate = ? " +
              "where hostid = ? and guestid = ?");
      stm.setDouble(1, guestReview.getRating());
      stm.setString(2, guestReview.getText());
      stm.setDate(3, (Date.valueOf(guestReview.getCreatedDate())));
      stm.setInt(4, guestReview.getHostId());
      stm.setInt(5, guestReview.getGuestId());
      stm.executeUpdate();
      connection.commit();
      return guestReview;
    } catch (SQLException throwables) {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<GuestReview> getAllGuestReviewsByHostId(int id)
  {
    try (Connection connection = getConnection()) {
      PreparedStatement stm = connection.prepareStatement("SELECT * FROM guestreview WHERE hostid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      List<GuestReview> guestReviews = new ArrayList<>();
      while (result.next()) {
        GuestReview guestReview = new GuestReview(
                result.getDouble("guestrating"),
                result.getString("guestreviewtext"),
                LocalDate.parse(result.getDate("createddate").toString()),
                result.getInt("guestid"),
                result.getInt("hostid"),
                hostDAO.getHostById(result.getInt("hostid")).getEmail());
        guestReviews.add(guestReview);
      }
      return guestReviews;
    } catch (SQLException throwables) {
      throw new IllegalStateException(throwables.getMessage());

    }
  }

  private Host getHostById(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN host h ON _user.userid = h.hostid where userid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      result.next();
      List<HostReview> hostReviews = new ArrayList<>();
      return new Host(result.getInt("userid"), result.getString("email"),
          result.getString("password"), result.getString("fname"),
          result.getString("lname"), result.getString("phonenumber"),result.getString("personalimage"),
          hostReviews,
          result.getString("cprnumber"), result.getBoolean("isapproved"));

    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
