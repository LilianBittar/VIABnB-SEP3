package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class HostReview
{
  private int id;
  private double rating;
  private String text;
  private Guest guest;

  public HostReview(int id, double rating, String text, Guest guest)
  {
    this.id = id;
    this.rating = rating;
    this.text = text;
    this.guest = guest;
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

  public Guest getGuest()
  {
    return guest;
  }

  public void setGuest(Guest guest)
  {
    this.guest = guest;
  }
}
