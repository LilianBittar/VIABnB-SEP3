package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;

import java.util.List;

public interface CityDAO
{
  /**
   * Return a City object based on a given parameter
   *
   * @param id The targeted city's id
   * @return City Object if any is found, or null
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  City getCityById(int id);
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
  List<City> getAll();
}
