package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import static org.mockito.Mockito.*;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;

import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import java.util.ArrayList;

class GuestControllerTest {
    private GuestDAO guestDAO;
    private GuestController controller;

    @BeforeEach
    void setup() {
        guestDAO = mock(GuestDAO.class);

        controller = new GuestController(guestDAO, mock(RentRequestDAO.class));
    }

    @Test
    void ControllerReturnsInternalServerErrorWhenRepositoryReturnsNull() {
        Guest guest = new Guest(1, "test", "test", "+4588888888", "test@test.com", "test123", new ArrayList<>(), null, "111111-1111", false, 293886, false);
        when(guestDAO.createGuest(guest)).thenReturn(null);
        ResponseEntity<Guest> response = controller.createGuest(guest);
        Assertions.assertEquals(ResponseEntity.internalServerError().build(), response);

        //todo test if statements in controller

    }
}