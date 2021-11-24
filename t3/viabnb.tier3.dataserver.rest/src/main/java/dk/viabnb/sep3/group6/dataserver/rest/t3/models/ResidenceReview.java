package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class ResidenceReview
{
  private double rating;
  private String reviewText;
  private Guest guest;

  public ResidenceReview(double rating, String reviewText,
      Guest guest)
  {
    this.rating = rating;
    this.reviewText = reviewText;
    this.guest = guest;
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

  public Guest getGuest()
  {
    return guest;
  }

  public void setGuest(Guest guest)
  {
    this.guest = guest;
  }
}
