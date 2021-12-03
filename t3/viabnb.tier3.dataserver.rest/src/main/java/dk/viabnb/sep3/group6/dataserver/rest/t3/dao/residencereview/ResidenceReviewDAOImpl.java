package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.ResidenceReview;

import java.sql.*;
import java.util.List;

public class ResidenceReviewDAOImpl extends BaseDao implements ResidenceReviewDAO{
    @Override
    public ResidenceReview create(Residence residence, ResidenceReview residenceReview) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("INSERT INTO residencereview(residencerating, residencereviewtext, residenceid, guestid, createddate) values (?,?,?,?,?)");
            stm.setDouble(1, residenceReview.getRating());
            stm.setString(2, residenceReview.getReviewText());
            stm.setInt(3, residence.getId());
            stm.setInt(4,getGuestIdByViaId(residenceReview.getGuestViaId()));
            stm.setDate(5, Date.valueOf(residenceReview.getCreatedDate()));
            stm.executeUpdate();
            connection.commit();
            return residenceReview;
        } catch (SQLException throwables) {
            throwables.printStackTrace();
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public ResidenceReview update(int residenceReviewId, ResidenceReview updatedResidenceReview) {
        return null;
    }

    @Override
    public List<ResidenceReview> getAllByResidenceId(int id) {
        return null;
    }

    /**
     * <p>
     *     Helper method for getting the {@code guestId} of a guest with a specific viaId.
     *     Works since viaId are unique in the system, so only 1 guest with a given viaId exists.
     * </p>
     * @return guestId as int, if none found then -1 is returned.
     * @throws IllegalStateException if connection to data source fails or query fails.
     * */
    private int getGuestIdByViaId(int viaId){
        try (Connection connection = getConnection()){
            PreparedStatement stm = connection.prepareStatement("select guestid from guest where viaid = ?");
            stm.setInt(1, viaId);
            ResultSet result = stm.executeQuery();

            if (result.next()) {
                return result.getInt(1);
            }

            return -1;
        } catch (SQLException throwables) {
            throwables.printStackTrace();
            throw new IllegalStateException(throwables.getMessage());
        }
    }
}
