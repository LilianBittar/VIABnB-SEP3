package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;

import java.util.List;

public interface GuestReviewDAO
{
  /**
   * Create a new GuestReview object and store it in a database
   *
   * @param guestReview The new object
   * @return newly created GuestReview object
   * @throws IllegalArgumentException if connection to database failed or executing the update failed
   */
  GuestReview createGuestReview(GuestReview guestReview);
  /**
   * Update a GuestReview object and store it in a database
   *
   * @param guestReview The new updated object
   * @return newly updated GuestReview object
   * @throws IllegalArgumentException if connection to database failed or executing the update failed
   */
  GuestReview updateGuestReview(GuestReview guestReview);
  /**
   * Query a list of GuestReview objects based on the given parameter
   *
   * @param id The id of the Guest whom the GuestReview objects belongs to
   * @return A list of GuestReview objects
   * @throws IllegalArgumentException if connection to database failed or query execution failed
   */
  List<GuestReview> getAllGuestReviewsByHostId(int id);
  /**
   * Query a list of GuestReview objects based on the given parameter
   *
   * @param id The targeted GuestReview's Guest's id
   * @return A list of GuestReview Object
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<GuestReview> getAllGuestReviewsByGuestId(int id);
}
