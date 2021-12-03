package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.ResidenceReview;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.List;

public class ResidenceReviewDAOImpl extends BaseDao implements ResidenceReviewDAO{
    @Override
    public ResidenceReview create(Residence residence, ResidenceReview residenceReview) {
        try (Connection connection = getConnection()) {
        } catch (SQLException throwables) {
            throwables.printStackTrace();
            throw new IllegalStateException(throwables.getMessage());
        }
        return null;
    }

    @Override
    public ResidenceReview update(int residenceReviewId, ResidenceReview updatedResidenceReview) {
        return null;
    }

    @Override
    public List<ResidenceReview> getAllByResidenceId(int id) {
        return null;
    }
}
