package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;

import java.util.List;

public interface AdministrationDAO
{
  List<HostRegistrationRequest> getAllHostRegistrationRequests();
  List<HostRegistrationRequest> getHostRegistrationRequestsByHostId(int hostId);
  HostRegistrationRequest getHostRegistrationRequestsById(int requestId);
  boolean isValidHost(int requestId, RequestStatus status);
}
