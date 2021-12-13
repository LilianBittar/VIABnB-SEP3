package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class GuestReviewDAOImpl extends BaseDao implements GuestReviewDAO
{
  @Override public GuestReview createGuestReview(GuestReview guestReview)
  {
    try (Connection connection = getConnection())
    {
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
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public GuestReview updateGuestReview(GuestReview guestReview)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement("UPDATE guestreview "
          + "SET guestrating = ?, guestreviewtext = ?, createddate = ? "
          + "where hostid = ? and guestid = ?");
      stm.setDouble(1, guestReview.getRating());
      stm.setString(2, guestReview.getText());
      stm.setDate(3, (Date.valueOf(guestReview.getCreatedDate())));
      stm.setInt(4, guestReview.getHostId());
      stm.setInt(5, guestReview.getGuestId());
      stm.executeUpdate();
      connection.commit();
      return guestReview;
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<GuestReview> getAllGuestReviewsByHostId(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM guestreview WHERE hostid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      List<GuestReview> guestReviews = new ArrayList<>();
      while (result.next())
      {
        GuestReview guestReview = new GuestReview(
            result.getDouble("guestrating"),
            result.getString("guestreviewtext"),
            LocalDate.parse(result.getDate("createddate").toString()),
            result.getInt("guestid"), result.getInt("hostid"));
        guestReviews.add(guestReview);
      }
      return guestReviews;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());

    }
  }

  @Override public List<GuestReview> getAllGuestReviewsByGuestId(int id)
  {
    List<GuestReview> guestReviewList = new ArrayList<>();
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
            result.getString("guestreviewtext"),
            LocalDate.parse(result.getDate("createddate").toString()),
            result.getInt("guestid"), result.getInt("hostid"));
        guestReviewList.add(guestReview);
      }
      return guestReviewList;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
