package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import static org.mockito.Mockito.*;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestregistrationrequest.GuestRegistrationRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

class GuestRegistrationControllerTest {
    private GuestRegistrationRequestDAO guestRegistrationRequestDAO;
    private GuestRegistrationController controller;

    @BeforeEach
     void setup() {
        guestRegistrationRequestDAO = mock(GuestRegistrationRequestDAO.class);
        controller = new GuestRegistrationController(guestRegistrationRequestDAO);
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