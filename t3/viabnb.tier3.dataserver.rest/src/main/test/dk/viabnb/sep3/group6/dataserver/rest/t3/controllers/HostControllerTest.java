package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class HostControllerTest
{
  private HostDAO hostDAO;
  private HostController controller;

  @BeforeEach
  void setup()
  {
    hostDAO = mock(HostDAO.class);
    controller = new HostController(hostDAO);
  }

  @Test
  void ControllerReturnsInternalServerErrorWhenRepositoryReturnsNull()
  {
    //Host host = new Host(1, "test", "test", "12345678", "email@test.tt", "Test123", new ArrayList<>(), "test", "1234567891", false);
    when(hostDAO.getAllNotApprovedHosts()).thenReturn(null);
    ResponseEntity<List<Host>> response = controller.getAllNotApprovedHosts();
    Assertions.assertEquals(ResponseEntity.internalServerError().build(), response);
  }
}