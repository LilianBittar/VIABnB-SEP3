package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequest;

import java.util.List;

public interface RentRequestDAO
{
  /**
   * Creates a new RentRequest object and stores the request in the database.
   *
   * @param request The new RentRequest object
   * @return the newly created RentRequest object
   * @throws IllegalStateException if connection to database failed or executing the query failed
   */
  RentRequest createNewRentRequest(RentRequest request);
  /**
   * Update a RentRequest object
   *
   * @param request The targeted rent request to update
   * @return The newly updated rent request
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  RentRequest updateRentRequest(RentRequest request);
  /**
   * Query a RentRequest object based on the given parameter
   *
   * @param id The targeted rent request's id
   * @return a RentRequest object if any is found, or null
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  RentRequest getRentRequestById(int id);
  /**
   * Query a list of RentRequest objects
   *
   * @return A list of RentRequest object
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<RentRequest> getAllRentRequests();
  /**
   * Update the status of a RentRequest object from false to true
   *
   * @param request The targeted RentRequest object to be updated
   * @return The newly updated rentRequest object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  RentRequest approveRentRequest(RentRequest request);
  /**
   * Remove a RentRequest object from the database
   *
   * @param request The targeted RentRequest object for removal
   * @return The newly removed RentRequest object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  RentRequest rejectRentRequest(RentRequest request);
}
