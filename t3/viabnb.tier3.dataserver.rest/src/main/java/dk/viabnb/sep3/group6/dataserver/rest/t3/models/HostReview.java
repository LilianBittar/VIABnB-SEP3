package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.time.LocalDate;

public class HostReview
{
  private double rating;
  private String text;
  private int viaId;
  private LocalDate createdDate;
  private int hostId;

  public HostReview(double rating, String text, int guestViaId, LocalDate createdDate, int hostId)
  {
    this.rating = rating;
    this.text = text;
    this.viaId = guestViaId;
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

  public int getViaId()
  {
    return viaId;
  }

  public void setViaId(int viaId)
  {
    this.viaId = viaId;
  }

  public LocalDate getCreatedDate() {
    return createdDate;
  }

  public void setCreatedDate(LocalDate createdDate) {
    this.createdDate = createdDate;
  }

  public int getHostId() {

    return hostId;
  }

  public void setHostId(int hostId) {
    this.hostId = hostId;
  }
}
