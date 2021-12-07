package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class Administrator extends User
{
  private String initials;

  public Administrator(int id, String email, String password, String firstName,
      String lastName, String phoneNumber, String profileImageUrl,
      String initials)
  {
    super(id, email, password, firstName, lastName, phoneNumber,
        profileImageUrl);
    this.initials = initials;
  }

  public String getInitials()
  {
    return initials;
  }

  public void setInitials(String initials)
  {
    this.initials = initials;
  }
}
