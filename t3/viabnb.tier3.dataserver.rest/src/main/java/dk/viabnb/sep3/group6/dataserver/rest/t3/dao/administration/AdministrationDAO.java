package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Administrator;

import java.util.List;

public interface AdministrationDAO
{
  /**
   * Query an Administrator object based on the given parameter
   *
   * @param email The targeted administrator's e-mail
   * @return an administrator object if any is found, or null
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  Administrator getAdministratorByEmail(String email);
  /**
   * Query a list of Administrator objects
   *
   * @return a list of Administrator object if any, or nul if there is non
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Administrator> getAllAdministrators();
}
