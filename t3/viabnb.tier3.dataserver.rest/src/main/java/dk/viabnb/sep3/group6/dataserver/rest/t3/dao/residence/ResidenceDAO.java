package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;

import java.util.List;

public interface ResidenceDAO
{
  /**
   * Query a Residence object based on the given parameter
   *
   * @param id The targeted Residence's id
   * @return Residence object if any, or null
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  Residence getResidenceById(int id);
  /**
   * Query a list of Residence objects based on the given parameter
   *
   * @param hostId The residence's Host's id
   * @return A list of Residence object
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Residence> getAllResidenceByHostId(int hostId);
  /**
   * Create a new Residence object and store it in the database
   *
   * @param residence The new Residence object
   * @return newly created Residence object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Residence createResidence(Residence residence);

  /**
   * Query a list of Residence objects
   *
   * @return a list of Residence objects
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Residence> getAllResidences();

  /**
   * Update start date, end date and sets availability to true
   *
   * @param residence The new updated Residence object
   * @return The newly updated Residence object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Residence updateAvailabilityPeriod(Residence residence);
  /**
   * Update a Residence object in the database
   *
   * @param residence The new updated Residence object
   * @return the newly updated Residence object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Residence updateResidence(Residence residence);
  /**
   * Delete a Residence object from the database
   *
   * @param residenceId The targeted Residence's id
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  void deleteResidence(int residenceId);
}
