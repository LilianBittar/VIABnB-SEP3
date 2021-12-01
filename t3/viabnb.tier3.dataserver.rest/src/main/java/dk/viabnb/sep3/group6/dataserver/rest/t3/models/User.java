package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class User
{
  private int id;
  private String email;
  private String password;

  public User(int id, String email, String password)
  {
    this.id = id;
    this.email = email;
    this.password = password;
  }
}
