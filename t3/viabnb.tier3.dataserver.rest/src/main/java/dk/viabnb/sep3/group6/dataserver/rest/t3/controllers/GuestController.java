package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController
public class GuestController {
    private static final Logger LOGGER= LoggerFactory.getLogger(GuestController.class);
    private GuestDAO guestDAO;

    @Autowired
    public GuestController(GuestDAO guestDAO) {
        this.guestDAO = guestDAO;
    }

    /**
     * Handles requests for creating new guests at endpoint /guests.
     * @param guest the Guest that is to be created.
     * @return HTTP OK with the newly created guest in the response body or
     * HTTP Internal Server Error response if Guest could not be created.
     * */
    @PostMapping("/guests")
    public ResponseEntity<Guest> createGuest(@RequestBody Guest guest) {
        LOGGER.info("Received createGuest request with params " + new Gson().toJson(guest) );
        Guest createGuest = null;
        try {
            createGuest = guestDAO.createGuest(guest);
        } catch (Exception e) {
            e.printStackTrace();
            LOGGER.error("createGuest request failed with: " + e.getMessage());
            return ResponseEntity.internalServerError().build();
        }

        if (createGuest == null) {
            LOGGER.error("createGuest request failed, new guest could not be created...");
            return ResponseEntity.internalServerError().build();
        }

        return ResponseEntity.ok(createGuest);
    }

    /**
     * Handles request for getting all guests in the system at endpoint /guests.
     * @param isApproved Optional field for filtering guests by isApproved value.
     * @return HTTP OK with all Guests in response body. If isApproved is provided,
     * then the list is filtered.
     * If Data access fails, then HTTP Internal Server Error is returned.
     * */
    @GetMapping("/guests")
    public ResponseEntity<List<Guest>> getAllGuests(@RequestParam(required = false) Boolean isApproved) {

        try {
            List<Guest> allGuests = guestDAO.getAllGuests();
            if (isApproved != null){
                allGuests.removeIf(g -> g.isApprovedGuest() != isApproved);
            }
            LOGGER.info("getAllGuests returned: " + new Gson().toJson(allGuests));
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

    @GetMapping("/guests") public ResponseEntity<Guest> getGuestByStudentNumber(
            @RequestParam(required = false) int studentNumber)
    {
        Guest guest;
        guest = guestDAO.getGuestByStudentNumber(studentNumber);
        if (guest == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(guest, HttpStatus.OK);
    }
    /**
     * End point of method type GET to get list of Guest objects with isApprovedGuest boolean value false
     * @return List<Guest>
     * */
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

    /**
     * End point of method type PATCH to update isApprovedGuest attribute for a given guest
     * @param guest The targeted Guest object
     * @param id The path variable used to identify the correct guest
     * @return A newly updated Guest object or ResponseEntity with bad request (depends on the given Guest object).
     * or ResponseEntity with not found when catching NoSuchElementException
     * */
    @RequestMapping(value = "/guests/{id}/approval", produces = "application/json", method = RequestMethod.PATCH)
    public ResponseEntity<Guest> updateGuestStatus(@RequestBody Guest guest, @PathVariable("id") int id)
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
