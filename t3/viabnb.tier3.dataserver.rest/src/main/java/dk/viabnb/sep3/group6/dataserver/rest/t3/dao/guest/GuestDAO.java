package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;

import java.util.List;

public interface GuestDAO {
    /**
     * Create a new Guest object
     * @param guest The new object to create
     * @return a newly created guest object
     *
     * @throws IllegalStateException invalid guest
     * */
    public Guest createGuest(Guest guest);
    /**
     * Query all the guests in the system
     * @return a list of  guest objects
     *
     * @throws IllegalStateException if it could not connect to the database
     * */
    public List<Guest> getAllGuests();
    /**
     * Update the boolean isApprovedGuest value of a given guest from false to true
     * @param guest The targeted guest
     * @return Updated Guest object with isApprovedGuest boolean value true
     *
     * @throws IllegalStateException on invalid guest
     * */
    public Guest approveGuest(Guest guest);
    /**
     * Delete a Host object that have a boolean isApprovedGuest value false
     * @param guest The targeted guest
     * @return Updated guest object with isApprovedGuest boolean value of false
     * @throws IllegalStateException invalid guest
     * */
    public Guest rejectGuest(Guest guest);
    /**
     * Query a guest based on the given parameter
     * @param id The targeted guest's id
     * @return guest object
     *
     * @throws  IllegalStateException invalid guest
     * */
    Guest getGuestByUserId(int id);
    /**
     * Query a list of Guest objects that have a false isApprovedGuest boolean value
     * @return a list of  guest that were not approved.
     *
     *@throws IllegalStateException if it could not connect to the database
     * */
    List<Guest> getAllNotApprovedGuests();
    /**
     * Handles querying the database for a guest with the provided student number.
     * @param studentNumber Required field for filtering guests by student number value.
     * @return a guest object or null if it could not find the guest with the provided student number.
     *
     * @throws IllegalStateException if it could not connect to the database
     * */
    Guest getGuestByStudentNumber(int studentNumber);
    /**
     * Query a guest based on the given parameter
     * @param email The targeted guest's email
     * @return guest object
     *
     * @throws  IllegalStateException invalid guest
     * */
    Guest getGuestByEmail(String email);

}
