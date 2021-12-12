package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.hostreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;

import java.util.List;

public interface HostReviewDAO
{
  /**
   * Create a new HostReview object and store it in the database
   *
   * @param hostReview The new HostReview object
   * @return newly created HostReview object
   * @throws IllegalArgumentException if connection to database failed or executing the update failed
   */
  HostReview createHostReview(HostReview hostReview);
  /**
   * Update a HostReview object and store it in a database
   *
   * @param hostReview The new updated HostReview object
   * @return newly updated HostReview object
   * @throws IllegalArgumentException if connection to database failed or executing the update failed
   */
  HostReview updateHostReview(HostReview hostReview);
  /**
   * Query a list of HostReview objects based on the given parameter
   *
   * @param hostId The targeted HostReview's Host's id
   * @return A lis of HostReviewObject
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<HostReview> getAllHostReviewsByHostId(int hostId);
}
