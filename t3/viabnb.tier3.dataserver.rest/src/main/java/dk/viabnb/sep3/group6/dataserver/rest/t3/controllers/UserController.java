package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.user.UserDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class UserController
{
  private static final Logger LOGGER = LoggerFactory.getLogger(
      UserController.class);
  private UserDAO userDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  @Autowired public UserController(UserDAO userDAO)
  {
    this.userDAO = userDAO;
  }

  @GetMapping("/users")
  public ResponseEntity<List<User>> getAllUsers(@RequestParam(required = false) String email)
  {
    List<User> users = userDAO.getAllUsers();
    try
    {
      if (email != null)
      {
        users.removeIf(user -> !user.getEmail().equals(email));
      }
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
    }
    return ResponseEntity.ok(users);
  }

  @GetMapping("/users/{id}")
  public ResponseEntity<User> getUserById(@PathVariable("id") int id)
  {
    User user = null;
    try
    {
      user = userDAO.getUserById(id);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
    }
    return ResponseEntity.ok(user);
  }

  @PatchMapping("/user/{id}")
  public ResponseEntity<User> updateUser(@RequestBody User user, @PathVariable("id") int id)
  {
    try
    {
      user = userDAO.updateUser(user);
      return ResponseEntity.ok(user);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @DeleteMapping("/user/{id}")
  public ResponseEntity<Void> deleteUser(@PathVariable("id") int id)
  {
    try
    {
      userDAO.deleteUser(id);
      return new ResponseEntity<>(HttpStatus.OK);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
    }
  }
}
