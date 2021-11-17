package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestregistrationrequest.GuestRegistrationRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController
public class GuestRegistrationController {

    private GuestRegistrationRequestDAO guestRegistrationRequestDAO;

    @Autowired
    public GuestRegistrationController(@Qualifier("guestRegistrationRequestJsonDAO") GuestRegistrationRequestDAO guestRegistrationRequestDAO) {
        this.guestRegistrationRequestDAO = guestRegistrationRequestDAO;
    }


    @PostMapping("/guestregistrationrequests")
    public ResponseEntity<GuestRegistrationRequest> createGuestRegistrationRequest(@RequestBody GuestRegistrationRequest request) {
        GuestRegistrationRequest createdRequest = guestRegistrationRequestDAO.createGuestRegistrationRequest(request);
        if (createdRequest == null) {
            return ResponseEntity.internalServerError().build();
        }
        return ResponseEntity.ok(createdRequest);
    }

    @GetMapping("/guestregistrationrequests")
    public ResponseEntity<List<GuestRegistrationRequest>> getAllGuestRegistrationRequests() {
       /*
       Maybe??
       List<GuestRegistrationRequest> requests;
        requests = administrationDAO.getAllGuestRegistrationRequest();
        if (requests == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(requests, HttpStatus.OK);*/
        return ResponseEntity.ok(guestRegistrationRequestDAO.getAllGuestRegistrationRequests());
    }

    /*
    former AdministrationController method
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
    }*/

    @PatchMapping("/guestregistrationrequests/{id}")
    public ResponseEntity<GuestRegistrationRequest> updateRequestStatus(@RequestBody GuestRegistrationRequest request) {
        try {
            if (request.getStatus() == RequestStatus.Approved) {
                GuestRegistrationRequest approvedRequest = guestRegistrationRequestDAO.approveGuestRegistrationRequest(request);
                return ResponseEntity.ok(approvedRequest);
            }
            else if (request.getStatus() == RequestStatus.NotApproved){
                GuestRegistrationRequest rejectedRequest = guestRegistrationRequestDAO.rejectGuestRegistrationRequest(request);
                return ResponseEntity.ok(rejectedRequest);
            }

            return ResponseEntity.badRequest().build();
        } catch (NoSuchElementException e) {
            return ResponseEntity.notFound().build();
        }
    }
    @GetMapping("/guestRequests/{id}")
    public ResponseEntity<List<GuestRegistrationRequest>> getGuestRegistrationRequestsByHostId(@PathVariable("id") int id)
    {
        GuestRegistrationRequest request;
        request = guestRegistrationRequestDAO.getGuestRegistrationRequestByHostId(id);
        if (request == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity(request, HttpStatus.OK);
    }

    @GetMapping("/guestRequests/{id2}")
    public ResponseEntity<GuestRegistrationRequest> getGuestRegistrationRequestsById(@PathVariable("id2") int id)
    {
        //Todo check @PathVariable
        GuestRegistrationRequest request;
        request = guestRegistrationRequestDAO.getGuestRegistrationRequestById(id);
        if (request == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(request, HttpStatus.OK);
    }
}
