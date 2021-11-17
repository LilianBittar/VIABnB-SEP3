package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.hostregistrationrequest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostRegistrationRequest;

import java.util.List;

public interface HostRegistrationRequestDAO
{
  List<HostRegistrationRequest> getAllHostRegistrationRequests();

  HostRegistrationRequest getHostRegistrationRequestsByHostId(int hostId);

  HostRegistrationRequest getHostRegistrationRequestsById(int requestId);

  public HostRegistrationRequest approveHostRegistrationRequest(HostRegistrationRequest request);

  public HostRegistrationRequest rejectHostRegistrationRequest(HostRegistrationRequest request);

}
