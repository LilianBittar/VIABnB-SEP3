package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.time.LocalDate;

public class ResidenceReview
{
  private double rating;
  private String reviewText;
  private int guestViaId;
  private LocalDate createdDate;

  public ResidenceReview(double rating, String reviewText, int guestViaId, LocalDate createdDate) {
    this.rating = rating;
    this.reviewText = reviewText;
    this.guestViaId = guestViaId;
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

  public LocalDate getCreatedDate() {
    return createdDate;
  }

  public void setCreatedDate(LocalDate createdDate) {
    this.createdDate = createdDate;
  }
}
