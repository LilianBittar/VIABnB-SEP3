package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;

import java.util.List;

public interface HostDAO
{
  /**
   * Create a new Host object and store in the database
   *
   * @param host The new host object
   * @return The newly created Host object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Host registerHost(Host host);
  /**
   * Query a Host object based on the given parameter
   *
   * @param email The targeted Host's e-mail
   * @return a Host object if anny is found, or null
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  Host getHostByEmail(String email);
  /**
   * Query a Host object based on the given parameter
   *
   * @param id The targeted Host's id
   * @return a host object if any is found, or null
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  Host getHostById(int id);
  /**
   * Query a list of Host objects that have a false isApprovedHost boolean value
   *
   * @return a list of Host objects
   * @throws IllegalStateException if can't connect to database
   */
  List<Host> getAllNotApprovedHosts();
  /**
   * Update the boolean isApprovedHost value of a given Host object from false to true
   *
   * @param host The targeted host
   * @return Updated Host object with isApprovedHost boolean value true
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Host approveHost(Host host);
  /**
   * Delete a Host object that have a boolean isApprovedHost value false
   *
   * @param host The targeted Host
   * @return Updated Host object with isApprovedHost boolean value of false
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Host rejectHost(Host host);
}
