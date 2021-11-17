package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;

import java.util.List;

public interface GuestDAO {
    public Guest createGuest(Guest guest);

    public List<Guest> getAllGuests();

    public Guest approveGuest(Guest guest);

    public Guest rejectGuest(Guest guest);

    Guest getGuestByHostId(int id);

    Guest getGuestRegistrationRequestById(int requestId);
}
