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

class AuthenticationControllerTest {
    private HostAuthenticationDAO hostAuthenticationDAO;
    private AuthenticationController authenticationController;

    @BeforeEach
     void setup() {
      hostAuthenticationDAO = mock(HostAuthenticationController.class);
      authenticationController = new AuthenticationController(hostAuthenticationDAO);
    }

    @Test
     void ControllerReturnsInternalServerErrorWhenRepositoryReturnsNullWithId() {
        int id = -1;
        when(hostAuthenticationDAO.getHostById(id)).thenReturn(null);
        ResponseEntity<Host> response = authenticationController.getHostById(id);
        assertEquals(ResponseEntity.internalServerError().build(), response);
    }
    @Test
    void ControllerReturnsInternalServerErrorWhenRepositoryReturnsNullWithEmail() {
        string email = "catman";
        when(hostAuthenticationDAO.getHostByEmail(email)).thenReturn(null);
        ResponseEntity<Host> response = authenticationController.getHostByEmail(email);
        assertEquals(ResponseEntity.internalServerError().build(), response);
    }
}