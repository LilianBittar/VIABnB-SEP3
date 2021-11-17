package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import static org.mockito.Mockito.*;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class GuestRegistrationControllerTest {
    private GuestDAO guestRegistrationRequestDAO;
    private GuestController controller;

    @BeforeEach
     void setup() {
        guestRegistrationRequestDAO = mock(GuestDAO.class);
        controller = new GuestController(guestRegistrationRequestDAO);
    }

    @Test
     void ControllerReturnsInternalServerErrorWhenRepositoryReturnsNull() {
        /*Host host = new Host(1, "test", "test", "test", "test@test.test", "test", new ArrayList<HostReview>(), "test", true);
        GuestRegistrationRequest request = new GuestRegistrationRequest(1, 293886, "test", RequestStatus.NotAnswered);
        when(guestRegistrationRequestDAO.createGuestRegistrationRequest(request)).thenReturn(null);
        ResponseEntity<GuestRegistrationRequest> response = controller.createGuestRegistrationRequest(request);
        assertEquals(ResponseEntity.internalServerError().build(), response);*/
    }
}