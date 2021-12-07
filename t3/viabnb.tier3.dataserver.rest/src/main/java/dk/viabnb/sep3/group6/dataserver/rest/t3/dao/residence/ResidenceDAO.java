package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;

import java.util.List;

public interface ResidenceDAO
{
  /**
   * Return a Residence object based on the given id
   * @param id The targeted residence id
   * @return Residence object
   * @throws IllegalStateException if can't connect to database
   * */
  Residence getByResidenceId(int id);
  /**
   * Return a list of Residence objects based on a host id
   * @param id The id of the host who owns the residence
   * @return List<Residence>
   * @throws IllegalStateException if can't connect to database
   * */
  List<Residence> getAllResidenceByHostId(int id);
  /**
   * Create a new Residence object in the database
   * @param residence The new Residence object
   * @return newly created Residence object
   * @throws IllegalStateException if can't connect to database
   * */
  Residence createResidence(Residence residence);

  /**
   * Returns all residences registered in the system
   * @return List of all residences
   * @throws IllegalStateException if can't connect to database
   * */
  List<Residence> getAllResidences() throws IllegalStateException;

  /**
   * updates start date, end date and sets availability to true
   * @param residence
   * @return updated residence
   * @throws IllegalStateException
   */
  Residence UpdateAvailabilityPeriod(Residence residence);
  /**
   * Update an existing residence in the system by identifying it and replacing its info
   * @param residence The new residence witch have the new arguments
   * @return the newly updated residence
   *
   * @throws IllegalStateException if can't connect to database
   * */
  Residence updateResidence(Residence residence);
}
