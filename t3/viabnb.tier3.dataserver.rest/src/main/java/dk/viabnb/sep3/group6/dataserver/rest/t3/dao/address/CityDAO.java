package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;

public interface CityDAO
{
  /**
   * Return an City object based on a given id
   * @param id The targeted city's id
   * @return City Object
   * @throws IllegalStateException on SQL failure or invalid id
   * */
  City getCityById(int id);
}
