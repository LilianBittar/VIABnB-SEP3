package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration.AdministrationDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class AdministrationController
{
  private AdministrationDAO administrationDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  @Autowired
  public AdministrationController(@Qualifier("administrationJsonDAO") AdministrationDAO administrationDAO)
  {
    this.administrationDAO = administrationDAO;
  }

  //Host
  @GetMapping("/hostRequests")
  public ResponseEntity<List<HostRegistrationRequest>> getAllHostRegistrationRequests()
  {
    List<HostRegistrationRequest> requests;
    requests = administrationDAO.getAllHostRegistrationRequests();
    if (requests == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(requests, HttpStatus.OK);
  }

  @RequestMapping(value = "/hostRequests/{id}", method = RequestMethod.PATCH,
  consumes = MediaType.APPLICATION_JSON_VALUE)
  public ResponseEntity<RequestStatus> isValidHost(@RequestBody RequestStatus update, @PathVariable("id") int id)
  {
    administrationDAO.isValidHost(id, update);
    if (update == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(update, HttpStatus.OK);
  }

  @GetMapping("/hostRequests/{id}")
  public ResponseEntity<List<HostRegistrationRequest>> getHostRegistrationRequestsByHostId(@PathVariable("id") int id)
  {
    List<HostRegistrationRequest> requests;
    requests = administrationDAO.getHostRegistrationRequestsByHostId(id);
    if (requests == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(requests, HttpStatus.OK);
  }

  @GetMapping("/hostRequests/{id2}")
  public ResponseEntity<HostRegistrationRequest> getHostRegistrationRequestsById(@PathVariable("id2") int id)
  {
    //Todo check @PathVariable
    HostRegistrationRequest request;
    request = administrationDAO.getHostRegistrationRequestsById(id);
    if (request == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(request, HttpStatus.OK);
  }

  //Guest
  @GetMapping("/guestRequests")
  public ResponseEntity<List<GuestRegistrationRequest>> getAllGuestRegistrationRequests()
  {
    List<GuestRegistrationRequest> requests;
    requests = administrationDAO.getAllGuestRegistrationRequest();
    if (requests == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(requests, HttpStatus.OK);
  }

  @RequestMapping(value = "/guestRequests/{id}", method = RequestMethod.PATCH,
      consumes = MediaType.APPLICATION_JSON_VALUE)
  public ResponseEntity<RequestStatus> isValidGuest(@RequestBody RequestStatus update, @PathVariable("id") int id)
  {
    administrationDAO.isValidHost(id, update);
    if (update == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(update, HttpStatus.OK);
  }

  @GetMapping("/guestRequests/{id}")
  public ResponseEntity<List<GuestRegistrationRequest>> getGuestRegistrationRequestsByHostId(@PathVariable("id") int id)
  {
    List<GuestRegistrationRequest> requests;
    requests = administrationDAO.getGuestRegistrationRequestByHosttId(id);
    if (requests == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(requests, HttpStatus.OK);
  }

  @GetMapping("/guestRequests/{id2}")
  public ResponseEntity<GuestRegistrationRequest> getGuestRegistrationRequestsById(@PathVariable("id2") int id)
  {
    //Todo check @PathVariable
    GuestRegistrationRequest request;
    request = administrationDAO.getGuestRegistrationRequestById(id);
    if (request == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(request, HttpStatus.OK);
  }
}
