package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.util.List;

public class Host
{
  private int id;
  private String firstName;
  private String lastName;
  private String phoneNumber;
  private String email;
  private String password;
  private List<HostReview> hostReviews;
  private String profileImageUrl;

  public Host(int id, String firstName, String lastName, String phoneNumber,
      String email, String password, List<HostReview> hostReviews,
      String profileImageUrl)
  {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.phoneNumber = phoneNumber;
    this.email = email;
    this.password = password;
    this.hostReviews = hostReviews;
    this.profileImageUrl = profileImageUrl;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
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

  public List<HostReview> getHostReviews()
  {
    return hostReviews;
  }

  public void setHostReviews(List<HostReview> hostReviews)
  {
    this.hostReviews = hostReviews;
  }

  public String getProfileImageUrl()
  {
    return profileImageUrl;
  }

  public void setProfileImageUrl(String profileImageUrl)
  {
    this.profileImageUrl = profileImageUrl;
  }
}
