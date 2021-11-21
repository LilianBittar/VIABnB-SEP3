package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
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
        Guest createdRequest = null;
        try {
            createdRequest = guestDAO.createGuest(guest);
        } catch (Exception e) {
            return ResponseEntity.internalServerError().build();
        }

        if (createdRequest == null) {
            return ResponseEntity.internalServerError().build();
        }

        return ResponseEntity.ok(createdRequest);
    }

    @GetMapping("/guests")
    public ResponseEntity<List<Guest>> getAllGuests(@RequestParam Boolean isApproved) {

        try {
            List<Guest> allGuests = guestDAO.getAllGuests();
            if (isApproved != null){
                allGuests.removeIf(g -> g.isApprovedGuest() != isApproved);
            }
            return ResponseEntity.ok(allGuests);
        } catch (Exception e) {
           return ResponseEntity.internalServerError().build();
        }
    }

    @GetMapping("/guests/{id}")
    public ResponseEntity<Guest> getGuestByHostId(@PathVariable("id") int id)
    {
        Guest guest;
        guest = guestDAO.getGuestByHostId(id);
        try {
            return ResponseEntity.ok(guest);
        } catch (Exception e) {
            return ResponseEntity.internalServerError().build();
        }
    }

    @GetMapping("/guests/notApproved")
    public ResponseEntity<List<Guest>> getAllNotApprovedGuests()
    {
        List<Guest> guestsToReturn = guestDAO.getAllNotApprovedGuests();
        if (guestsToReturn == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(guestsToReturn, HttpStatus.OK);
    }

    @PatchMapping("/guest/{id}/approval")
    public ResponseEntity<Guest> updateGuestStatus(@RequestBody Guest guest, @RequestParam("id") int id)
    {
        try
        {
            if (guest.isApprovedGuest())
            {
                Guest approvedGuest = guestDAO.approveGuest(guest);
                return ResponseEntity.ok(approvedGuest);
            }
            else if (!guest.isApprovedGuest())
            {
                Guest rejectedGuest = guestDAO.rejectGuest(guest);
                return ResponseEntity.ok(rejectedGuest);
            }
            return ResponseEntity.badRequest().build();
        }
        catch (NoSuchElementException e)
        {
            return ResponseEntity.notFound().build();
        }
    }
}
