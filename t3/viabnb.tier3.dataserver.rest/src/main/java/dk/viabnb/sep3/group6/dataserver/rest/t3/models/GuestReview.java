package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class GuestReview
{
  private int id;
  private double rating;
  private String text;
  private Host host;

  public GuestReview(int id, double rating, String text, Host host)
  {
    this.id = id;
    this.rating = rating;
    this.text = text;
    this.host = host;
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

  public Host getHost()
  {
    return host;
  }

  public void setHost(Host host)
  {
    this.host = host;
  }
}
