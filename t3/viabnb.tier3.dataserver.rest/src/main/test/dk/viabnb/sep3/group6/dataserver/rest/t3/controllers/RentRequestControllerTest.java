package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import java.time.LocalDate;
import java.util.ArrayList;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

import static org.junit.jupiter.api.Assertions.*;

class RentRequestControllerTest
{
  private RentRequestDAO rentRequestDAO;
  private RentRequestController controller;
  private Guest guest;
  private Residence residence;

  @BeforeEach public void setUp()
  {
    rentRequestDAO = mock(RentRequestDAO.class);
    controller = new RentRequestController(rentRequestDAO);
    guest = new Guest(1, "test@test.com", "test", "test", "test", "+4588888888",
        null, new ArrayList<>(), "111111-1111", true, 293886, new ArrayList<>(),
        true);

    City city = new City(1, "test", 8700);
    Address address = new Address(1, "test", "1t", "1t", city);
  }

  @Test public void createRentRequestNullRequestReturnsBadRequest()
  {
    RentRequest request = null;
    assertEquals(ResponseEntity.badRequest().build(),
        controller.createRentRequest(request));
  }

  @Test public void createRentRequestRentRepositoryDoesNotCreateRequestReturnsInternalServerError()
  {
    RentRequest request = new RentRequest(1, LocalDate.now(), LocalDate.now(),
        1, RentRequestStatus.NOTANSWERED, guest, residence, LocalDate.now());
    when(rentRequestDAO.createNewRentRequest(request)).thenReturn(null);
    assertEquals(ResponseEntity.internalServerError().build(),
        controller.createRentRequest(request));
  }

  @Test public void createRentRequestRentRepositoryThrowsIllegalStateReturnsInternalServerError()
  {
    RentRequest request = new RentRequest(1, LocalDate.now(), LocalDate.now(),
        1, RentRequestStatus.NOTANSWERED, guest, residence, LocalDate.now());
    when(rentRequestDAO.createNewRentRequest(request)).thenThrow(
        IllegalStateException.class);
    assertEquals(ResponseEntity.internalServerError().build(),
        controller.createRentRequest(request));
  }

  @Test public void updateRentRequestDoesNotUpdateRentRequestReturnsInternalServerErrorTest()
  {
    RentRequest request = new RentRequest(1, LocalDate.now(), LocalDate.now(),
        1, RentRequestStatus.NOTANSWERED, guest, residence, LocalDate.now());
    when(rentRequestDAO.updateRentRequest(request)).thenReturn(null);
    assertEquals(ResponseEntity.badRequest().build(),
        controller.updateRentRequestStatus(request, 1));
  }

  @Test public void updateRentRequestDoesNotUpdateRentRequestThrowsInternalServerErrorTest()
  {
    RentRequest request = new RentRequest(1, LocalDate.now(), LocalDate.now(),
        1, RentRequestStatus.NOTANSWERED, guest, residence, LocalDate.now());
    when(rentRequestDAO.updateRentRequest(request)).thenThrow(
        IllegalStateException.class);
    assertEquals(ResponseEntity.badRequest().build(),
        controller.updateRentRequestStatus(request, 1));
  }
}