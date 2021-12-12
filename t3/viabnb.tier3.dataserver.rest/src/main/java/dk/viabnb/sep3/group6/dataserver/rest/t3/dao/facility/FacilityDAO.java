package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Facility;

import java.util.List;

public interface FacilityDAO
{
  /**
   * Create a new facility object and store it in the database
   *
   * @param facility    The new facility
   * @param residenceId The Residence's id which the Facility belongs to
   * @return the newly created facility
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Facility createResidenceFacility(Facility facility, int residenceId);
  /**
   * Query a list Facility objects
   *
   * @return a list of Facility objects
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Facility> getAllFacilities();
  /**
   * Query a Facility object based on the given parameter
   *
   * @param id The targeted Facility's id
   * @return a Facility object if any is found, or null
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  Facility getFacilityById(int id);
  /**
   * Delete a facility from the database
   *
   * @param residenceId The targeted Facility to delete
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  void deleteResidenceFacility(int facilityId, int residenceId);
}
