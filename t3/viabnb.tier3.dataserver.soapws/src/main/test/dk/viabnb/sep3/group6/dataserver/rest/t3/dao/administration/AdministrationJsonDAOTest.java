package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class AdministrationJsonDAOTest
{
  private AdministrationDAO administrationDAO;
  private GuestRegistrationRequest guestRegistrationRequest;
  private HostRegistrationRequest hostRegistrationRequest;
  private Host host;

  @BeforeEach void setUp()
  {
    administrationDAO = new AdministrationJsonDAO();
    host = new Host(1, "fName", "lName", "1654", "email@r", "1234", null, "image", false);
    guestRegistrationRequest = new GuestRegistrationRequest(1, 1234, "image", RequestStatus.NotAnswered);
    hostRegistrationRequest = new HostRegistrationRequest(1, "Image", "123456", RequestStatus.NotAnswered, host);
  }


  @Test void getAllHostRegistrationRequestsSunnyScenario()
  {
    assertDoesNotThrow(()-> administrationDAO.getAllHostRegistrationRequests());
  }

  @Test void getHostRegistrationRequestsByHostIdSunnyScenario()
  {
    assertDoesNotThrow(()-> administrationDAO.getHostRegistrationRequestsByHostId(host.getId()));
  }

  @Test void getHostRegistrationRequestsByIdSunnyScenario()
  {
    assertDoesNotThrow(()-> administrationDAO.getHostRegistrationRequestsById(hostRegistrationRequest.getId()));
  }

  @Test void isValidHostSunnyScenario()
  {
    assertDoesNotThrow(()-> administrationDAO.isValidHost(hostRegistrationRequest.getId(), RequestStatus.Approved));
  }

  @Test void getAllGuestRegistrationRequestSunnyScenario()
  {
    assertDoesNotThrow(()-> administrationDAO.getAllGuestRegistrationRequest());
  }

  @Test void getGuestRegistrationRequestByHostIdSunnyScenario()
  {
    assertDoesNotThrow(()-> administrationDAO.getGuestRegistrationRequestByHostId(host.getId()));
  }

  @Test void getGuestRegistrationRequestByIdSunnyScenario()
  {
    assertDoesNotThrow(()-> administrationDAO.getGuestRegistrationRequestById(guestRegistrationRequest.getId()));
  }

  @Test void isValidGuestSunnyScenario()
  {
    assertDoesNotThrow(()-> administrationDAO.isValidGuest(guestRegistrationRequest.getId(), RequestStatus.Approved));
  }
}