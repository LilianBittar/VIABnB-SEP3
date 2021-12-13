package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.ResidenceReview;

import java.util.List;

public interface ResidenceReviewDAO
{
  /**
   * Creates a new ResidenceReview object and stores it in the databse
   *
   * @param residence       the Residence which the ResidenceReview is intended for.
   * @param residenceReview the newly created ResidenceReview object that is to be created.
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  ResidenceReview createResidenceReview(Residence residence,
      ResidenceReview residenceReview);

  /**
   * Updates an existing Residence review object by updating the reviews fields to match the fields of {@code updatedResidenceReview}
   * and stores the new state in the database.
   *
   * @param residenceId            id of the Residence that the ResidenceReview is intended for.
   * @param updatedResidenceReview ResidenceReview object with the desired state that the review should have after update.
   * @throws IllegalStateException if connection to data source fails or executing the update fails.
   */
  ResidenceReview updateResidenceReview(int residenceId,
      ResidenceReview updatedResidenceReview);

  /**
   * Query a list of residence reviews based on the given parameter
   *
   * @param residenceId The targeted Residence's id
   * @return a list of ResidenceReview objects
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<ResidenceReview> getAllResidenceReviewsByResidenceId(int residenceId);
}
