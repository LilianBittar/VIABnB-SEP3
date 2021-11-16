package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestregistrationrequest.GuestRegistrationRequestDAO;
import org.junit.jupiter.api.BeforeEach;

import static org.junit.jupiter.api.Assertions.*;

class GuestRegistrationControllerTest {
    private GuestRegistrationRequestDAO guestRegistrationRequestDAO;
    private GuestRegistrationController controller;

    @BeforeEach
    private void setup(){

        controller = new GuestRegistrationController(guestRegistrationRequestDAO);
    }
}