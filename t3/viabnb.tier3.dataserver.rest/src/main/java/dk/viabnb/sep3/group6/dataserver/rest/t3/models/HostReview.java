package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class HostReview
{
  private int id;
  private double rating;
  private String text;
  private int viaId;

  public HostReview(int id, double rating, String text, int viaId)
  {
    this.id = id;
    this.rating = rating;
    this.text = text;
    this.viaId = viaId;
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

  public int getViaId()
  {
    return viaId;
  }

  public void setViaId(int viaId)
  {
    this.viaId = viaId;
  }
}
