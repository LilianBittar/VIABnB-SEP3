package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.util.List;
//TODO missing List<GuestReview> from constructor refactor later with group
public class Guest extends Host
{
  private int viaId;
  private List<GuestReview> guestReviews;
  private boolean isApprovedGuest;

  public Guest(int id, String firstName, String lastName, String phoneNumber,
      String email, String password, List<HostReview> hostReviews,
      String profileImageUrl, String cpr, boolean isApprovedHost, int viaId, boolean isApprovedGuest)
  {
    super(id, firstName, lastName, phoneNumber, email, password, hostReviews,
        profileImageUrl, cpr, isApprovedHost);
    this.viaId = viaId;
    this.isApprovedGuest = isApprovedGuest;
  }

  //TODO temp constructor
  public Guest(int id, String firstName, String lastName, String phoneNumber,
      String email, String password, List<HostReview> hostReviews,
      String profileImageUrl, String cpr, boolean isApprovedHost, int viaId,
      List<GuestReview> guestReviews, boolean isApprovedGuest)
  {
    super(id, firstName, lastName, phoneNumber, email, password, hostReviews,
        profileImageUrl, cpr, isApprovedHost);
    this.viaId = viaId;
    this.guestReviews = guestReviews;
    this.isApprovedGuest = isApprovedGuest;
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

  public boolean isApprovedGuest()
  {
    return isApprovedGuest;
  }

  public void setApprovedGuest(boolean approvedGuest)
  {
    isApprovedGuest = approvedGuest;
  }
}
