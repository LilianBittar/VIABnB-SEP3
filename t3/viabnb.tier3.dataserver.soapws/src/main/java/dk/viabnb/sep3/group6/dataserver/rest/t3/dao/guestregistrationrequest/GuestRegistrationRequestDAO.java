package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestregistrationrequest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;

import java.util.List;

public interface GuestRegistrationRequestDAO {
    public GuestRegistrationRequest createGuestRegistrationRequest(GuestRegistrationRequest request);

    public List<GuestRegistrationRequest> getAllGuestRegistrationRequests();

    public GuestRegistrationRequest approveGuestRegistrationRequest(GuestRegistrationRequest request);

    public GuestRegistrationRequest rejectGuestRegistrationRequest(GuestRegistrationRequest request);
}
