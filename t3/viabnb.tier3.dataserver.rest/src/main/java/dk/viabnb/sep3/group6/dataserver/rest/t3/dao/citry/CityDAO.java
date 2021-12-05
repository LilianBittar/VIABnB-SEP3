package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;

public interface CityDAO
{
  /**
   * Return an City object based on a given id
   * @param id The targeted city's id
   * @return City Object
   *
   * @throws IllegalStateException id can't connect to database
   * */
  City getCityById(int id);
  /**
   * Create a new City object
   * @param city The new city
   * @return the newly created city object
   *
   * @throws IllegalStateException id can't connect to database
   * */
  City createNewCity(City city);
}
