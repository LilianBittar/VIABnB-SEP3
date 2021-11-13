package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestregistrationrequest.GuestRegistrationRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
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
        return ResponseEntity.ok(guestRegistrationRequestDAO.getAllGuestRegistrationRequests());
    }

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

}
