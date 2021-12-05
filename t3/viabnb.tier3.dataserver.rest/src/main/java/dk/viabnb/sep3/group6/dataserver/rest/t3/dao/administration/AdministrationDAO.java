package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Administrator;

import java.util.List;

public interface AdministrationDAO
{
  /**
   * Handle a query to return an administrator object based on the given parameter
   * @param email The targeted admin's emain
   * @return an administrator object if found, and a null if not found
   *
   * @throws IllegalStateException if can't connect to database
   * */
  Administrator getAdministratorByEmail(String email);
  /**
   * Handle a query that returns a list of administrator objects
   * @return a list of Administrator object if any, or nul if there is non
   * */
  List<Administrator> getAllAdministrators();
}
