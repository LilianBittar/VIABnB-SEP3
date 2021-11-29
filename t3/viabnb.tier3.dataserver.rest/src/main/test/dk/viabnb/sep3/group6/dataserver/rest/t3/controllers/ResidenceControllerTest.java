package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Date;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class ResidenceControllerTest
{
  private ResidenceDAO residenceDAO;
  private ResidenceController controller;
  private Host host;
  private City city;
  private Address address;

  @BeforeEach
  public void setUp()
  {
    residenceDAO = mock(ResidenceDAO.class);
    controller = new ResidenceController(residenceDAO);
    host = new Host(1, "Test", "Test", "11111111", "Test@Test.ss", "Aa11", new ArrayList<>(), "Test", "1111111111", true);
    city = new City(1, "Test", 1111);
    address = new Address(1, "Test", "Test", "Test", city);
  }

  @Test
  public void registerANullResidenceReturnsBadRequestTest()
  {
    Residence residenceTest = null;
    assertEquals(ResponseEntity.badRequest().build(), controller.createResidence(residenceTest));
  }

  @Test
  public void failureOnCreateResidenceReturnsInternalServerErrorTest()
  {
    Residence residenceTest = new Residence(1, address, "Test", "Test", true, 11, new ArrayList<>(), new ArrayList<>(),
         "Test", new Date("2022-11-11"), new Date("12-12-2022"), 3, host, new ArrayList<>());
    when(residenceDAO.createResidence(residenceTest)).thenReturn(null);
    assertEquals(ResponseEntity.internalServerError().build(), controller.createResidence(residenceTest));
  }
    @Test
    public void getAllReturnsInternalServerErrorWhenIllegalStateExceptionIsThrown(){
        when(residenceDAO.getAllResidences()).thenThrow(IllegalStateException.class);
        assertEquals(ResponseEntity.internalServerError().build(), controller.getAll());
    }

}