package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.ResidenceReview;

import java.util.List;

public interface ResidenceReviewDAO {
    ResidenceReview create(Residence residence, ResidenceReview residenceReview);
    ResidenceReview update(int residenceReviewId, ResidenceReview updatedResidenceReview);
    List<ResidenceReview> getAllByResidenceId(int id);
}
