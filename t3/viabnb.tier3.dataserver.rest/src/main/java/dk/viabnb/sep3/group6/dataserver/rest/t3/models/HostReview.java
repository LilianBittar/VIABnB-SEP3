package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class HostReview<LocalDate>
{
  private double rating;
  private String text;
  private int viaId;
  private LocalDate createdDate;

  public HostReview(double rating, String text, int guestViaId, LocalDate createdDate)
  {
    this.rating = rating;
    this.text = text;
    this.viaId = guestViaId;
    this.createdDate = createdDate;
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
}
