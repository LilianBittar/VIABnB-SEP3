package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;

import java.util.List;

public interface GuestDAO {
    public Guest createGuest(Guest guest);
    public List<Guest> getAllGuests();
    /**
     * Update the boolean isApprovedGuest value of a given guest from false to true
     * @param guest The targeted guest
     * @return Updated Guest object with isApprovedGuest boolean value true
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
    Guest getGuestByUserId(int id);
    /**
     * Query a list of Guest objects that have a false isApprovedGuest boolean value
     * @return List<Guest>
     * @throws IllegalStateException
     * */
    List<Guest> getAllNotApprovedGuests();
    /**
     * Handles querying the database for a guest with the provided student number.
     * @param studentNumber Required field for filtering guests by student number value.
     * @return a guest object or null if it could not find the guest with the provided student number.
     * @throws IllegalStateException if it could not connect to the database
     * */
    Guest getGuestByStudentNumber(int studentNumber);

}
