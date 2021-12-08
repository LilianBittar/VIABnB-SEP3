package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.time.LocalDate;

public class GuestReview
{

  private double rating;
  private String text;
  private LocalDate createdDate;
  private int guestId;
  private int hostId;

  public GuestReview(double rating, String text,  LocalDate createdDate, int guestId, int hostId)
  {
    this.rating = rating;
    this.text = text;
    this.createdDate = createdDate;
    this.guestId = guestId;
    this.hostId=hostId;
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

  public LocalDate getCreatedDate() {
    return createdDate;
  }

  public void setCreatedDate(LocalDate createdDate) {
    this.createdDate = createdDate;
  }

  public int getGuestId() {
    return guestId;
  }

  public int getHostId() {
    return hostId;
  }

  public void setGuestId(int guestId) {
    this.guestId = guestId;
  }

  public void setHostId(int hostId) {
    this.hostId = hostId;
  }
}
