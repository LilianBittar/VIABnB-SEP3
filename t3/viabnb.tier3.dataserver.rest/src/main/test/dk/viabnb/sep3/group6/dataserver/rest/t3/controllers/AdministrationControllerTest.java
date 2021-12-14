package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration.AdministrationDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Administrator;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.User;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class AdministrationControllerTest
{
  private AdministrationDAO administrationDAO;
  private AdministrationController controller;
  private User user;

  @BeforeEach public void setUp()
  {
    administrationDAO = mock(AdministrationDAO.class);
    controller = new AdministrationController(administrationDAO);
    user = new Administrator(1, "Test@test.tt", "Aa11", "Test", "Test", "11111",
        "Test", "TT");
  }

  @Test public void getAdminByEmailReturnsInternalServerErrorWhenRepositoryThrowsIllegalStateExceptionTest()
  {
    String email = "test";
    when(administrationDAO.getAdministratorByEmail(email)).thenThrow(
        IllegalStateException.class);
    assertEquals(ResponseEntity.internalServerError().build(),
        controller.getAdminByEmail(email));
  }
}