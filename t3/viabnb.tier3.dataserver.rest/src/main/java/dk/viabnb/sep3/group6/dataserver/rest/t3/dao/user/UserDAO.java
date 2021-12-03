package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.user;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;

import java.util.List;

public interface UserDAO
{
  User getUserByEmail(String email);
  User getUserById(int id);
  List<User> getAllUsers();
}
