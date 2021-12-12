package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.user;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;

import java.util.List;

public interface UserDAO
{
  /**
   * Query a User object based on the given parameter
   *
   * @param id The targeted User's id
   * @return a User object
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  User getUserById(int id);
  /**
   * Query that a list of User objects
   *
   * @return a list of User objects
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<User> getAllUsers();
  /**
   * Update an existing User object and store it in the database
   *
   * @param user The new updated User object
   * @return the newly updated User object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  User updateUser(User user);
  /**
   * Delete a User object from th system
   *
   * @param userid The targeted User's id
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  void deleteUser(int userid);
}
