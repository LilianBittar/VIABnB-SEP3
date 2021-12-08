package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;

import java.util.List;

public interface GuestReviewDAO
{
  /**
   * Method to create a new GuestReview object and store it in a database
   *
   * @param guestReview The new object
   * @return newly created GuestReview object
   *
   * @throws IllegalArgumentException if can't connect to database
   * */
  GuestReview createGuestReview(GuestReview guestReview);
  /**
   * Method to update a GuestReview object and store it in a database
   *
   * @param guestReview The new updated object
   * @return newly updated GuestReview object
   *
   * @throws IllegalArgumentException if can't connect to database
   * */
  GuestReview updateGuestReview(GuestReview guestReview);
  /**
   * Method that query a list of guest reviews
   * @param id The id of the guest whom the reviews belongs to
   * @return A list of GuestReview objects with a guest id that matches the given parameter
   *
   * @throws IllegalArgumentException if can't connect to database
   * */
  List<GuestReview> getAllGuestReviewsByHostId(int id);
}
