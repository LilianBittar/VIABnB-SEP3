package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.ResidenceReview;

import java.util.List;

public interface ResidenceReviewDAO {
    /**
     * Creates a new {@code ResidenceReview} and stores it in DB.
     *
     * @param residence       the residence the review is intended for.
     * @param residenceReview the review that is to be created.
     * @throws IllegalStateException if connection to data source fails or executing the update fails.
     */
    ResidenceReview createResidenceReview(Residence residence, ResidenceReview residenceReview) throws IllegalStateException;

    /**
     * Updates an existing {@code ResidenceReview} by updating the reviews fields to match the fields of {@code updatedResidenceReview}
     * and stores the new state in DB.
     *
     * @param residenceId      id of the residence that the review is intended for.
     * @param updatedResidenceReview ResidenceReview object with the desired state that the review should have after update.
     * @throws IllegalStateException if connection to data source fails or executing the update fails.
     */
    ResidenceReview updateResidenceReview(int residenceId, ResidenceReview updatedResidenceReview) throws IllegalStateException;

    /**
     * Handle a query that returns a list of residence reviews based on the given parameter
     * @param id The targeted residence parameter
     * @return a list of residence objects
     *
     * @throws IllegalStateException if can't connect to database
     * */
    List<ResidenceReview> getAllResidenceReviewsByResidenceId(int residenceId);
}
