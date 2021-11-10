package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.util.List;

public class Guest extends Host
{
  private int viaId;
  private List<GuestReview> guestReviews;

  public Guest(int id, String firstName, String lastName, String phoneNumber,
      String email, String password, List<HostReview> hostReviews,
      String profileImageUrl)
  {
    super(id, firstName, lastName, phoneNumber, email, password, hostReviews,
        profileImageUrl);
  }

  public int getViaId()
  {
    return viaId;
  }

  public void setViaId(int viaId)
  {
    this.viaId = viaId;
  }

  public List<GuestReview> getGuestReviews()
  {
    return guestReviews;
  }

  public void setGuestReviews(List<GuestReview> guestReviews)
  {
    this.guestReviews = guestReviews;
  }
}
