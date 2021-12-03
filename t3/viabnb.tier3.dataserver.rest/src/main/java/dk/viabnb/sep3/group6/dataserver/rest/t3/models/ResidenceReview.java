package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class ResidenceReview
{
  private double rating;
  private String reviewText;
  private int guestViaId;

  public ResidenceReview(double rating, String reviewText,
                         int guestViaId)
  {
    this.rating = rating;
    this.reviewText = reviewText;
    this.guestViaId = guestViaId;
  }

  public double getRating()
  {
    return rating;
  }

  public void setRating(double rating)
  {
    this.rating = rating;
  }

  public String getReviewText()
  {
    return reviewText;
  }

  public void setReviewText(String reviewText)
  {
    this.reviewText = reviewText;
  }

  public int getGuestViaId()
  {
    return guestViaId;
  }

  public void setGuestViaId(int guestViaId)
  {
    this.guestViaId = guestViaId;
  }
}
