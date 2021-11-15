package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;

import java.util.List;

public interface AdministrationDAO
{
  //Host
  List<HostRegistrationRequest> getAllHostRegistrationRequests();
  HostRegistrationRequest getHostRegistrationRequestsByHostId(int hostId);
  HostRegistrationRequest getHostRegistrationRequestsById(int requestId);
  boolean isValidHost(int requestId, RequestStatus status);
  //Guest
  List<GuestRegistrationRequest> getAllGuestRegistrationRequest();
  GuestRegistrationRequest getGuestRegistrationRequestByHostId(int hostId);
  GuestRegistrationRequest getGuestRegistrationRequestById(int requestId);
  boolean isValidGuest(int requestId, RequestStatus status);
}
