package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.hostreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;
import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class HostReviewDAOImpl extends BaseDao implements HostReviewDAO {

    private GuestDAO guestDAO = new GuestDAOImpl();

    @Override
    public HostReview createHostReview(HostReview hostReview) throws IllegalStateException {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "INSERT INTO hostreview(hostrating, hostreviewtext, guestid, createddate, hostid) VALUES(?,?,?,?,?)");
            stm.setDouble(1, hostReview.getRating());
            stm.setString(2, hostReview.getText());
            stm.setInt(3, guestDAO.getGuestByStudentNumber(hostReview.getViaId()).getId());
            stm.setDate(4, (Date.valueOf(hostReview.getCreatedDate())));
            stm.setInt(5, hostReview.getHostId());
            stm.executeUpdate();
            connection.commit();
            return hostReview;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public HostReview updateHostReview(HostReview hostReview) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("UPDATE hostview " +
                    "SET hostrating = ?, hostreviewtext = ?, createddate = ? " +
                    "where hostid = ? and guestid = ?");
            stm.setDouble(1, hostReview.getRating());
            stm.setString(2, hostReview.getText());
            stm.setDate(3, (Date.valueOf(hostReview.getCreatedDate())));
            stm.setInt(4, hostReview.getHostId());
            stm.setInt(5, guestDAO.getGuestByStudentNumber(hostReview.getViaId()).getId());
            stm.executeUpdate();
            connection.commit();
            return hostReview;
        } catch (SQLException throwables) {
            throwables.printStackTrace();
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public List<HostReview> getAllHostReviewsByHostId(int id) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("SELECT * FROM hostreview WHERE hostid = ?");
            stm.setInt(1, id);
            ResultSet result = stm.executeQuery();
            List<HostReview> hostReviews = new ArrayList<>();
            while (result.next()) {
                HostReview hostReview = new HostReview(
                        result.getDouble("hostrating"),
                        result.getString("hostreviewtext"),
                        guestDAO.getGuestByUserId(result.getInt("guestid")).getViaId(),
                        LocalDate.parse(result.getDate("createddate").toString()),
                        result.getInt("hostid"));
                hostReviews.add(hostReview);
            }
            return hostReviews;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());

        }
    }
}
