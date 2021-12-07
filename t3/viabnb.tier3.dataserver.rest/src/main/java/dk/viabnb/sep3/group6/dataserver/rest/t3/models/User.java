package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class User
{
  private int id;
  private String email;
  private String password;
  private String firstName;
  private String lastName;
  private String phoneNumber;
  private String profileImageUrl;

  public User(int id, String email, String password, String firstName,
      String lastName, String phoneNumber, String profileImageUrl)
  {
    this.id = id;
    this.email = email;
    this.password = password;
    this.firstName = firstName;
    this.lastName = lastName;
    this.phoneNumber = phoneNumber;
    this.profileImageUrl = profileImageUrl;
  }

  public String getProfileImageUrl()
  {
    return profileImageUrl;
  }

  public void setProfileImageUrl(String profileImageUrl)
  {
    this.profileImageUrl = profileImageUrl;
  }

  public String getFirstName()
  {
    return firstName;
  }

  public void setFirstName(String firstName)
  {
    this.firstName = firstName;
  }

  public String getLastName()
  {
    return lastName;
  }

  public void setLastName(String lastName)
  {
    this.lastName = lastName;
  }

  public String getPhoneNumber()
  {
    return phoneNumber;
  }

  public void setPhoneNumber(String phoneNumber)
  {
    this.phoneNumber = phoneNumber;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public String getEmail()
  {
    return email;
  }

  public void setEmail(String email)
  {
    this.email = email;
  }

  public String getPassword()
  {
    return password;
  }

  public void setPassword(String password)
  {
    this.password = password;
  }
}
