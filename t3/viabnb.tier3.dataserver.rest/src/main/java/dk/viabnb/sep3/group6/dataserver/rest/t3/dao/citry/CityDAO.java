package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;

import java.util.List;

public interface CityDAO
{
  /**
   * Create a new City object and store in in the database
   *
   * @param city The new city
   * @return the newly created city object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  City createNewCity(City city);
  /**
   * Query a list of City objects
   *
   * @return a list of City objetcs
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<City> getAllCities();
}
