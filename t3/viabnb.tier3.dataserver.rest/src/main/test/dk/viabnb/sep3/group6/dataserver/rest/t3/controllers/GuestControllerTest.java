package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import static org.mockito.Mockito.*;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
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
        controller = new GuestController(guestDAO);
    }

    @Test
    void ControllerReturnsInternalServerErrorWhenRepositoryReturnsNull() {
//        Guest guest = new Guest(1, "test", "test", "+4588888888", "test@test.test", "test", new ArrayList<HostReview>(), "test", false, 293886, new ArrayList<GuestReview>(), false);
//        when(guestDAO.createGuest(guest)).thenReturn(null);
//        ResponseEntity<Guest> response = controller.createGuest(guest);
//        Assertions.assertEquals(ResponseEntity.internalServerError().build(), response);

    }
}