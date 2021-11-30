package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import static org.junit.jupiter.api.Assertions.assertEquals;
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
    private Guest guest;

    @BeforeEach
    void setup() {
        guestDAO = mock(GuestDAO.class);
        controller = new GuestController(guestDAO);
        guest = new Guest
                (1,
                        "test",
                        "test",
                        "+4588888888",
                        "test@test.com",
                        "test",
                        new ArrayList<>(),
                        null,
                        "111111-1111",
                        true,
                        293886,
                        true
                );

    }

    @Test
    public void createANullGuestReturnsBadRequestTest()
    {
        Guest guest = null;
        assertEquals(ResponseEntity.internalServerError().build(), controller.createGuest(guest));
    }


    @Test
    public void failureOnCreateGuestReturnsInternalServerErrorTest()
    {
        //when(guestDAO.createGuest(guest)).thenReturn(null);
        assertEquals(ResponseEntity.internalServerError().build(), controller.createGuest(guest));
    }

    @Test
    public void createAGuestWithAnExistingViaIdReturnsAnErrorMessage()
    {
        assertEquals(ResponseEntity.internalServerError().build(), controller.createGuest(guest));
    }



























}