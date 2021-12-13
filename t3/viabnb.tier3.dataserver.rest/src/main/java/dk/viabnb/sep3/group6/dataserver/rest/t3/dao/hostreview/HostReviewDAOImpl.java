package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.hostreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class HostReviewDAOImpl extends BaseDao implements HostReviewDAO
{
  @Override public HostReview createHostReview(HostReview hostReview)
      throws IllegalStateException
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "INSERT INTO hostreview(hostrating, hostreviewtext, guestid, createddate, hostid) VALUES(?,?,?,?,?)");
      stm.setDouble(1, hostReview.getRating());
      stm.setString(2, hostReview.getText());
      stm.setInt(3, hostReview.getGuestId());
      stm.setDate(4, (Date.valueOf(hostReview.getCreatedDate())));
      stm.setInt(5, hostReview.getHostId());
      stm.executeUpdate();
      connection.commit();
      return hostReview;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public HostReview updateHostReview(HostReview hostReview)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement("UPDATE hostreview "
          + "SET hostrating = ?, hostreviewtext = ?, createddate = ? "
          + "where hostid = ? and guestid = ?");
      stm.setDouble(1, hostReview.getRating());
      stm.setString(2, hostReview.getText());
      stm.setDate(3, (Date.valueOf(hostReview.getCreatedDate())));
      stm.setInt(4, hostReview.getHostId());
      stm.setInt(5, hostReview.getGuestId());
      stm.executeUpdate();
      connection.commit();
      return hostReview;
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<HostReview> getAllHostReviewsByHostId(int hostId)
  {
    List<HostReview> hostReviewList = new ArrayList<>();
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM hostreview WHERE hostid = ?");
      stm.setInt(1, hostId);
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        HostReview hostReview = new HostReview(result.getDouble("hostrating"),
            result.getString("hostreviewtext"), result.getInt("guestid"),
            LocalDate.parse(result.getDate("createddate").toString()),
            result.getInt("hostid"));
        hostReviewList.add(hostReview);
      }
      return hostReviewList;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
