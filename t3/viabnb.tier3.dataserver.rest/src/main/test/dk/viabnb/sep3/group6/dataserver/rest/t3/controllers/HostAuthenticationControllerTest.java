package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import static org.mockito.Mockito.*;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl.HostJsonDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.http.ResponseEntity;

import static org.junit.jupiter.api.Assertions.*;

class HostAuthenticationControllerTest
{
    private HostDAO hostDAO;
    private HostController hostController;

    @BeforeEach
     void setup() {
      hostDAO = mock(HostJsonDAO.class);
      hostController = new HostController(hostDAO);
    }

    @Test
     void ControllerReturnsInternalServerErrorWhenRepositoryReturnsNullWithId() {
        int id = -1;
        when(hostDAO.getHostById(id)).thenReturn(null);
        ResponseEntity<Host> response = hostController.getHostById(id);
        assertEquals(ResponseEntity.internalServerError().build(), response);
    }
    @Test
    void ControllerReturnsInternalServerErrorWhenRepositoryReturnsNullWithEmail() {
        String email = "catman";
        when(hostDAO.getHostByEmail(email)).thenReturn(null);
        ResponseEntity<Host> response = hostController.getHostByEmail(email);
        assertEquals(ResponseEntity.internalServerError().build(), response);
    }
}