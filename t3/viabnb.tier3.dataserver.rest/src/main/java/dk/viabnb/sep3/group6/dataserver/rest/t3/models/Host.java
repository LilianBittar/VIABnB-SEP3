package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class Host extends User
{
  private List<HostReview> hostReviews;
  private String cpr;
  private boolean isApprovedHost;

  public Host(int id, String email, String password, String firstName,
      String lastName, String phoneNumber, String profileImageUrl,
      List<HostReview> hostReviews, String cpr, boolean isApprovedHost)
  {
    super(id, email, password, firstName, lastName, phoneNumber,
        profileImageUrl);
    this.hostReviews = hostReviews;
    this.cpr = cpr;
    this.isApprovedHost = isApprovedHost;
  }

  public List<HostReview> getHostReviews()
  {
    return hostReviews;
  }

  public void setHostReviews(List<HostReview> hostReviews)
  {
    this.hostReviews = hostReviews;
  }

  public String getCpr()
  {
    return cpr;
  }

  public void setCpr(String cpr)
  {
    this.cpr = cpr;
  }

  @JsonProperty("isApprovedHost") public boolean isApprovedHost()
  {
    return isApprovedHost;
  }

  public void setApprovedHost(boolean approvedHost)
  {
    isApprovedHost = approvedHost;
  }
}
