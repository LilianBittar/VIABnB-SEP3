package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;

import java.util.List;

//Todo implement later. Now use the AdministrationJsonDAO
public class AdministrationDAOImpl implements AdministrationDAO
{
  @Override public List<HostRegistrationRequest> getAllHostRegistrationRequests()
  {
    return null;
  }

  @Override public List<HostRegistrationRequest> getHostRegistrationRequestsByHostId(
      int hostId)
  {
    return null;
  }

  @Override public HostRegistrationRequest getHostRegistrationRequestsById(
      int requestId)
  {
    return null;
  }

  @Override public boolean isValidHost(int requestId, RequestStatus status)
  {
    return false;
  }

  @Override public List<GuestRegistrationRequest> getAllGuestRegistrationRequest()
  {
    return null;
  }

  @Override public List<GuestRegistrationRequest> getGuestRegistrationRequestByHosttId(
      int hostId)
  {
    return null;
  }

  @Override public GuestRegistrationRequest getGuestRegistrationRequestById(
      int requestId)
  {
    return null;
  }

  @Override public boolean isValidGuest(int requestId, RequestStatus status)
  {
    return false;
  }

}
