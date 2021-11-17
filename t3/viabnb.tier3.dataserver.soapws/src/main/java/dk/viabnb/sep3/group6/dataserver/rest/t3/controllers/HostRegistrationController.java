package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.hostregistrationrequest.HostRegistrationRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController public class HostRegistrationController
{
  private HostRegistrationRequestDAO hostRegistrationRequestDAO;

  @Autowired

  public HostRegistrationController(
      @Qualifier("hostRegistrationRequestJsonDAO") HostRegistrationRequestDAO hostRegistrationRequestDAO)
  {
    this.hostRegistrationRequestDAO = hostRegistrationRequestDAO;
  }

  @GetMapping("/hostregistrationrequests") public ResponseEntity<List<HostRegistrationRequest>> getAllHostRegistrationRequests()
  {
    List<HostRegistrationRequest> requests;
    requests = hostRegistrationRequestDAO.getAllHostRegistrationRequests();
    if (requests == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(requests, HttpStatus.OK);
  }

  @GetMapping("/hostregistrationrequests/host/{id}") public ResponseEntity<HostRegistrationRequest> getHostRegistrationRequestsByHostId(
      @PathVariable("id") int id)
  {
    HostRegistrationRequest request;
    request = hostRegistrationRequestDAO.getHostRegistrationRequestsByHostId(id);
    if (request == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return ResponseEntity.ok(request);
  }

  @GetMapping("/hostregistrationrequests/{id}") public ResponseEntity<HostRegistrationRequest> getHostRegistrationRequestsById(
      @PathVariable("id") int id)
  {
    HostRegistrationRequest request;
    request = hostRegistrationRequestDAO.getHostRegistrationRequestsById(id);
    if (request == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return ResponseEntity.ok(request);
  }

  @PatchMapping(value = "/hostregistrationrequests/{id}") public ResponseEntity<HostRegistrationRequest> updateRequestStatus(
      @RequestBody HostRegistrationRequest request)
  {
    try
    {
      if (request.getStatus() == RequestStatus.Approved)
      {
        HostRegistrationRequest approvedRequest = hostRegistrationRequestDAO.approveHostRegistrationRequest(
            request);
        return ResponseEntity.ok(approvedRequest);
      }
      else if (request.getStatus() == RequestStatus.NotApproved)
      {
        HostRegistrationRequest rejectedRequest = hostRegistrationRequestDAO.rejectHostRegistrationRequest(
            request);
        return ResponseEntity.ok(rejectedRequest);
      }
      return ResponseEntity.badRequest().build();
    }
    catch (NoSuchElementException e)
    {
      return ResponseEntity.notFound().build();
    }
  }
}
