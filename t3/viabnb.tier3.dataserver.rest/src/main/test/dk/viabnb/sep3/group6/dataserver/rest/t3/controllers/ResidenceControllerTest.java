package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview.ResidenceReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import java.time.LocalDate;
import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class ResidenceControllerTest {
    private ResidenceDAO residenceDAO;
    private ResidenceController controller;
    private Host host;
    private City city;
    private Address address;
    private ResidenceReviewDAO residenceReviewDAO;

    @BeforeEach
    public void setUp() {
        residenceDAO = mock(ResidenceDAO.class);
        residenceReviewDAO = mock(ResidenceReviewDAO.class);
        controller = new ResidenceController(residenceDAO, residenceReviewDAO);
        host = new Host(1, "Test", "Test", "11111111", "Test@Test.ss", "Aa11", new ArrayList<>(), "Test", "1111111111"
                , true);
        city = new City(1, "Test", 1111);
        address = new Address(1, "Test", "Test", "Test", city);
    }

    @Test
    public void registerANullResidenceReturnsBadRequestTest() {
        Residence residenceTest = null;
        assertEquals(ResponseEntity.badRequest().build(), controller.createResidence(residenceTest));
    }

    @Test
    public void failureOnCreateResidenceReturnsInternalServerErrorTest() {
        Residence residenceTest = new Residence(1, address, "Test", "Test", true, 11, new ArrayList<>(),
                new ArrayList<>(),
                "Test", null, null, 3, host, new ArrayList<>());
        when(residenceDAO.createResidence(residenceTest)).thenReturn(null);
        assertEquals(ResponseEntity.internalServerError().build(), controller.createResidence(residenceTest));
    }

    @Test
    public void getAllReturnsInternalServerErrorWhenIllegalStateExceptionIsThrown() {
        when(residenceDAO.getAllResidences()).thenThrow(IllegalStateException.class);
        assertEquals(ResponseEntity.internalServerError().build(), controller.getAll());
    }

    @Test
    public void createReviewReturnsBadRequestWhenResidenceReviewIsNullI() {
        assertEquals(ResponseEntity.badRequest().build(), controller.createReview(1, null));
    }

    @Test
    public void createReviewReturnsBadRequestWhenResidenceIdIsZero() {
        assertEquals(ResponseEntity.badRequest().build(), controller.createReview(0, new ResidenceReview(1, "test", 293886, LocalDate.now())));
    }
    @Test
    public void createReviewReturnsBadRequestWhenResidenceIdIsMinusOne() {
        assertEquals(ResponseEntity.badRequest().build(), controller.createReview(-1, new ResidenceReview(1, "test", 293886, LocalDate.now())));
    }
    @Test
    public void createReviewReturnsBadRequestWhenResidenceIdIsMinusTen() {
        assertEquals(ResponseEntity.badRequest().build(), controller.createReview(-10, new ResidenceReview(1, "test", 293886, LocalDate.now())));
    }
    @Test
    public void createReviewReturnsInternalServerErrorWhenDAOThrowsIllegalArgumentException(){
        Residence residence = new Residence(1, address, "Test", "Test", true, 11, new ArrayList<>(),
                new ArrayList<>(),
                "Test", null, null, 3, host, new ArrayList<>());
        ResidenceReview residenceReview = new ResidenceReview(1, "test", 293886, LocalDate.now());
        when(residenceReviewDAO.create(residence, residenceReview)).thenThrow(IllegalStateException.class);
        assertEquals(ResponseEntity.internalServerError().build(), controller.createReview(residence.getId(), residenceReview));
    } @Test
    public void createReviewReturnsInternalServerErrorWhenCreatedReviewIsNull(){
        Residence residence = new Residence(1, address, "Test", "Test", true, 11, new ArrayList<>(),
                new ArrayList<>(),
                "Test", null, null, 3, host, new ArrayList<>());
        ResidenceReview residenceReview = new ResidenceReview(1, "test", 293886, LocalDate.now());
        when(residenceReviewDAO.create(residence, residenceReview)).thenReturn(null);
        assertEquals(ResponseEntity.internalServerError().build(), controller.createReview(residence.getId(), residenceReview));
    }


}