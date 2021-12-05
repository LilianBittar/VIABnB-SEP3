package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class GuestReviewDAOImpl extends BaseDao implements GuestReviewDAO
{
  private static final Logger LOGGER = LoggerFactory.getLogger(
      GuestReviewDAO.class);

  @Override public GuestReview createGuestReview(GuestReview guestReview)
  {
    return null;
  }

  @Override public GuestReview updateGuestReview(GuestReview guestReview)
  {
    return null;
  }

  @Override public List<GuestReview> getAllGuestReviewsByGuestId(int id)
  {
    List<GuestReview> guestReviews = new ArrayList<>();
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM guestreview WHERE guestid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        GuestReview guestReview = new GuestReview(
            result.getDouble("guestrating"),
            result.getString("guestreviewtext"), getHostById(result.getInt("hostid")).getEmail(),
            LocalDate.parse(result.getDate("createddate").toString()));
        guestReviews.add(guestReview);
      }
      return guestReviews;
    }
    catch (SQLException throwables)
    {
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
          result.getString("lname"), result.getString("phonenumber"),
          hostReviews, result.getString("personalimage"),
          result.getString("cprnumber"), result.getBoolean("isapproved"));

    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
