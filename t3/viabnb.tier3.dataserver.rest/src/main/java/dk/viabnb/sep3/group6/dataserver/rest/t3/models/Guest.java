package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;
//TODO missing List<GuestReview> from constructor refactor later with group
public class Guest extends Host
{
  private int viaId;
  private List<GuestReview> guestReviews;
  @JsonProperty("isApprovedGuest")
  private boolean isApprovedGuest;

  public Guest(int id, String email, String password, String firstName,
      String lastName, String phoneNumber, List<HostReview> hostReviews,
      String profileImageUrl, String cpr, boolean isApprovedHost, int viaId,
      List<GuestReview> guestReviews, boolean isApprovedGuest)
  {
    super(id, email, password, firstName, lastName, phoneNumber, hostReviews,
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
