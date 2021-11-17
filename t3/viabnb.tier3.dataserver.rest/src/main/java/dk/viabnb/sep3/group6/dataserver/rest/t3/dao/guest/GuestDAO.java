package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;

import java.util.List;

public interface GuestDAO {
    public Guest createGuestRegistrationRequest(Guest request);

    public List<Guest> getAllGuestRegistrationRequests();

    public Guest approveGuestRegistrationRequest(Guest request);

    public Guest rejectGuestRegistrationRequest(Guest request);

    Guest getGuestRegistrationRequestByHostId(int hostId);

    Guest getGuestRegistrationRequestById(int requestId);
}
