package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;

import java.util.List;

public interface GuestDAO
{
  /**
   * Create a new Guest object and store it in the database
   *
   * @param guest The new Guest object to create
   * @return a newly created guest object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Guest createGuest(Guest guest);
  /**
   * Query a list of Guest objects
   *
   * @return a list of Quest objects
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Guest> getAllGuests();
  /**
   * Update the boolean isApprovedGuest value of a given guest from false to true
   *
   * @param guest The targeted guest
   * @return Updated Guest object with isApprovedGuest boolean value true
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Guest approveGuest(Guest guest);
  /**
   * Delete a Guest object that have a boolean isApprovedGuest value false
   *
   * @param guest The targeted guest
   * @return Updated guest object with isApprovedGuest boolean value of false
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Guest rejectGuest(Guest guest);
  /**
   * Query a Guest object based on the given parameter
   *
   * @param id The targeted Guest's id
   * @return Guest object if any is found, or null
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  Guest getGuestByUserId(int id);
  /**
   * Query a list of Guest objects that have a false isApprovedGuest boolean value
   *
   * @return a list of Guest objects that were not approved.
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Guest> getAllNotApprovedGuests();
}
