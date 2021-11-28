package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import org.apache.coyote.Response;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import java.util.ArrayList;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;
import static org.junit.jupiter.api.Assertions.*;

class ResidenceControllerTest {
    private ResidenceController controller;
    private ResidenceDAO residenceDAO;

    @BeforeEach
    public void setUp(){
        residenceDAO = mock(ResidenceDAO.class);
        controller = new ResidenceController(residenceDAO);
    }

    @Test
    public void GetAllReturnsInternalServerErrorWhenIllegalStateExceptionIsThrown(){
        when(residenceDAO.getAllResidences()).thenThrow(IllegalStateException.class);
        assertEquals(ResponseEntity.internalServerError().build(), controller.getAll());
    }

}