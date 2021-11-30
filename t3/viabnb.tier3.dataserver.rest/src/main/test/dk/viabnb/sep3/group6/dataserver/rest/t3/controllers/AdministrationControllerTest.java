package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration.AdministrationDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Administrator;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.platform.commons.logging.LoggerFactory;
import org.springframework.http.ResponseEntity;

import java.util.logging.Logger;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class AdministrationControllerTest
{
  private AdministrationDAO administrationDAO;
  private AdministrationController controller;
  private Administrator administrator;

  @BeforeEach
  public void setUp()
  {
    administrationDAO = mock(AdministrationDAO.class);
    controller = new AdministrationController(administrationDAO);
    administrator = new Administrator
        (
            1,
            "Test",
            "Test",
            "Test@test.tt",
            "11111111",
            "Aa11"
        );
  }

  @Test
  public void getAdminByEmailReturnsInternalServerErrorWhenRepositoryThrowsIllegalStateExceptionTest()
  {
    String email = "test";
    when(administrationDAO.getAdministratorByEmail(email)).thenThrow(IllegalStateException.class);
    assertEquals(ResponseEntity.internalServerError().build(), controller.getAdminByEmail(email));
  }
}