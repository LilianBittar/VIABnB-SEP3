package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Facility;

import java.util.List;

public interface FacilityDAO
{
  /**
   * Create a new facility object in the system
   * @param facility The new facility
   * @return the newly created facility
   *
   * @throws IllegalStateException if can't connect to database
   * */
  Facility createFacility(Facility facility);
  /**
   * Handles query a list of all the facilities in the system
   * @return a list of facility objects
   *
   * @throws IllegalStateException if can't connect to database
   * */
  List<Facility> getAllFacilities();
  /**
   * Handle query a facility based on the given parameter
   * @param id The targeted facility's id
   *
   * @throws IllegalStateException if can't connect to database
   * */
  Facility getFacilityById(int id);
}
