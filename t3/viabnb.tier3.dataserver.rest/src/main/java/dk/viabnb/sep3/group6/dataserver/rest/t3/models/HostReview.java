package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.time.LocalDate;

public class HostReview
{
  private double rating;
  private String text;
  private int guestId;
  private LocalDate createdDate;
  private int hostId;

  public HostReview(double rating, String text, int guestId,
      LocalDate createdDate, int hostId)
  {
    this.rating = rating;
    this.text = text;
    this.guestId = guestId;
    this.createdDate = createdDate;
    this.hostId = hostId;
  }

  public double getRating()
  {
    return rating;
  }

  public void setRating(double rating)
  {
    this.rating = rating;
  }

  public String getText()
  {
    return text;
  }

  public void setText(String text)
  {
    this.text = text;
  }

  public int getGuestId()
  {
    return guestId;
  }

  public void setGuestId(int guestId)
  {
    this.guestId = guestId;
  }

  public LocalDate getCreatedDate()
  {
    return createdDate;
  }

  public void setCreatedDate(LocalDate createdDate)
  {
    this.createdDate = createdDate;
  }

  public int getHostId()
  {

    return hostId;
  }

  public void setHostId(int hostId)
  {
    this.hostId = hostId;
  }
}
