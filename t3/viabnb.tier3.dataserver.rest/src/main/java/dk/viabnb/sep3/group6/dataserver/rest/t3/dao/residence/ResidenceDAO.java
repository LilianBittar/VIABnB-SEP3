package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;

import java.util.List;

public interface ResidenceDAO
{
  /**
   * Return a Residence object based on the given id
   * @param id The targeted residence id
   * @return Residence object
   * @throws IllegalStateException on SQL failure or invalid id
   * */
  Residence getByResidenceId(int id) throws IllegalStateException;
  /**
   * Return a list of Residence objects based on a host id
   * @param id The id of the host who owns the residence
   * @return List<Residence>
   * @throws IllegalStateException on SQL failure or invalid id
   * */
  List<Residence> getAllResidenceByHostId(int id);
  /**
   * Create a new Residence object in the database
   * @param residence The new Residence object
   * @return newly created Residence object
   * @throws IllegalStateException on SQL failure or invalid residence
   * */
  Residence createResidence(Residence residence) throws IllegalStateException;

  /**
   * Returns all residences registered in the system
   * @return List of all residences
   * @throws IllegalStateException if connection to data source could not be established.
   * */
  List<Residence> getAllResidences() throws IllegalStateException;

  /**
   * updates start date, end date and sets availability to true
   * @param residence
   * @return updated residence
   * @throws IllegalStateException on SQL failure or invalid residence
   */
  Residence UpdateAvailabilityPeriod(Residence residence) throws IllegalStateException;
}
