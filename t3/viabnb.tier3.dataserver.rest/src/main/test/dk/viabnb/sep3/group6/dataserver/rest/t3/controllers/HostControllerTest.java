package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class HostControllerTest
{
  private HostDAO hostDAO;
  private HostController controller;

  @BeforeEach void setup()
  {
    hostDAO = mock(HostDAO.class);
    controller = new HostController(hostDAO);
  }

  @Test public void registerHostNullRequestReturnsBadRequest()
  {
    //arrange
    Host host = null;

    //act and assert
    assertEquals(ResponseEntity.badRequest().build(),
        controller.createHost(host));
  }

  @Test void controllerReturnsInternalServerErrorWhenRepositoryReturnsNull()
  {
    //arrange
    Host host = new Host(1, "test", "test", "12345678", "email@test.tt",
        "Test123", "test", new ArrayList<>(), "1234567891", false);
    when(hostDAO.registerHost(host)).thenReturn(null);

    //act and assert
    Assertions.assertEquals(ResponseEntity.internalServerError().build(),
        controller.createHost(host));
  }

  @Test void controllerReturnsInternalServerErrorWhenRepositoryReturnsNullTest()
  {
    //aarange
    Host host = new Host(1, "test", "test", "12345678", "email@test.tt",
        "Test123", "test", new ArrayList<>(), "1234567891", false);
    when(hostDAO.registerHost(host)).thenThrow(IllegalStateException.class);

    //act and assert
    Assertions.assertEquals(ResponseEntity.internalServerError().build(),
        controller.createHost(host));
  }

}