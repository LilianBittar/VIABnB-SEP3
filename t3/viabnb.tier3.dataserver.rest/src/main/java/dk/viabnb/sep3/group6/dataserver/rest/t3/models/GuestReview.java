package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class GuestReview
{
  private int id;
  private double rating;
  private String text;
  private int hostId;

  public GuestReview(int id, double rating, String text, int hostId)
  {
    this.id = id;
    this.rating = rating;
    this.text = text;
    this.hostId = hostId;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
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

  public int getHostId()
  {
    return hostId;
  }

  public void setHostId(int hostId)
  {
    this.hostId = hostId;
  }
}
