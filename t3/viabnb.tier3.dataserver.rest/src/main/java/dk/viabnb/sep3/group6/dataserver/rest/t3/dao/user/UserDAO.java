package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.user;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;

import java.util.List;

public interface UserDAO
{
  /**
   * Handle a query that returns a user object based on the given parameter
   * @param email The targeted user's email
   * @return a user object
   *
   * @throws IllegalStateException if can't connect to database
   * */
  User getUserByEmail(String email);
  /**
   * Handle a query that returns a user object based on the given parameter
   * @param id The targeted user's id
   * @return a user object
   *
   * @throws IllegalStateException if can't connect to database
   * */
  User getUserById(int id);
  /**
   * Handle a query that returns a list of all the users in tghe system
   * @return a list of user objects
   *
   * @throws IllegalStateException if can't connect to database
   * */
  List<User> getAllUsers();
}
