package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController
public class GuestController {

    private GuestDAO guestDAO;

    @Autowired
    public GuestController(GuestDAO guestDAO) {
        this.guestDAO = guestDAO;
    }


    @PostMapping("/guests")
    public ResponseEntity<Guest> createGuest(@RequestBody Guest guest) {
        Guest createdRequest = guestDAO.createGuestRegistrationRequest(guest);
        if (createdRequest == null) {
            return ResponseEntity.internalServerError().build();
        }
        return ResponseEntity.ok(createdRequest);
    }

    @GetMapping("/guests")
    public ResponseEntity<List<Guest>> getAllGuests() {
       /*
       Maybe??
       List<GuestRegistrationRequest> requests;
        requests = administrationDAO.getAllGuestRegistrationRequest();
        if (requests == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(requests, HttpStatus.OK);*/
        return ResponseEntity.ok(guestDAO.getAllGuestRegistrationRequests());
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

    @PatchMapping("/guests/{id}")
    public ResponseEntity<Guest> updateRequestStatus(@RequestBody Guest guest) {
        try {
//            if (guest.isApprovedGuest() == RequestStatus.Approved) {
//                Guest approvedRequest = guestDAO.approveGuestRegistrationRequest(guest);
//                return ResponseEntity.ok(approvedRequest);
//            }
//            else if (guest.isApprovedGuest() == RequestStatus.NotApproved){
//                Guest rejectedRequest = guestDAO.rejectGuestRegistrationRequest(guest);
//                return ResponseEntity.ok(rejectedRequest);
//            }

            return ResponseEntity.badRequest().build();
        } catch (NoSuchElementException e) {
            return ResponseEntity.notFound().build();
        }
    }
    @GetMapping("/guests/{id}")
    public ResponseEntity<List<GuestRegistrationRequest>> getGuestByHostId(@PathVariable("id") int id)
    {
        Guest guest;
        guest = guestDAO.getGuestRegistrationRequestByHostId(id);
        if (guest == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity(guest, HttpStatus.OK);
    }

}
