package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequest;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController public class GuestController
{
  private static final Logger LOGGER = LoggerFactory.getLogger(
      GuestController.class);
  private GuestDAO guestDAO;
  private RentRequestDAO rentRequestDAO;

  @Autowired public GuestController(GuestDAO guestDAO,
      RentRequestDAO rentRequestDAO)
  {
    this.guestDAO = guestDAO;
    this.rentRequestDAO = rentRequestDAO;
  }

  @PostMapping("/guests") public ResponseEntity<Guest> createGuest(
      @RequestBody Guest guest)
  {
    LOGGER.info(
        "Received createGuest request with params " + new Gson().toJson(guest));
    Guest createGuest = null;
    try
    {
      createGuest = guestDAO.createGuest(guest);
    }
    catch (Exception e)
    {
      e.printStackTrace();
      LOGGER.error("createGuest request failed with: " + e.getMessage());
      return ResponseEntity.internalServerError().build();
    }

    if (createGuest == null)
    {
      LOGGER.error(
          "createGuest request failed, new guest could not be created...");
      return ResponseEntity.internalServerError().build();
    }

    return ResponseEntity.ok(createGuest);
  }

  @GetMapping("/guests") public ResponseEntity<List<Guest>> getAllGuests(
      @RequestParam(required = false) Boolean isApproved,
      @RequestParam(required = false) Integer studentNumber,
      @RequestParam(required = false) String email)
  {

    if (email != null){
      LOGGER.info(email);
    }
    try
    {
      List<Guest> allGuests = guestDAO.getAllGuests();
      if (isApproved != null)
      {
        allGuests.removeIf(g -> g.isApprovedGuest() != isApproved);
      }
      if (studentNumber != null)
      {
        allGuests.removeIf(g -> g.getViaId() != studentNumber);
      }
      if (email != null)
      {
        LOGGER.info(this + "Was provided: " + email);
        allGuests.removeIf(guest -> !guest.getEmail().equals(email));
      }
      LOGGER.info("getAllGuests returned: " + new Gson().toJson(allGuests));
      return ResponseEntity.ok(allGuests);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @GetMapping("/guests/{id}") public ResponseEntity<Guest> getGuestByHostId(
      @PathVariable("id") int id)
  {
    Guest guest;
    guest = guestDAO.getGuestByUserId(id);
    try
    {
      return ResponseEntity.ok(guest);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @GetMapping("/guests/notApproved") public ResponseEntity<List<Guest>> getAllNotApprovedGuests()
  {
    List<Guest> guestsToReturn = guestDAO.getAllNotApprovedGuests();

    return new ResponseEntity<>(guestsToReturn, HttpStatus.OK);
  }

  @RequestMapping(value = "/guests/{id}/approval", produces = "application/json", method = RequestMethod.PATCH) public ResponseEntity<Guest> updateGuestStatus(
      @RequestBody Guest guest, @PathVariable("id") int id)
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

  @GetMapping("/guests/{id}/rentrequests") public ResponseEntity<List<RentRequest>> getRentRequestByGuestId(
      @PathVariable int id)
  {
    try
    {
      List<RentRequest> rentRequests = rentRequestDAO.getAllRentRequests();
      rentRequests.removeIf(request -> request.getGuest().getId() == id);
      return ResponseEntity.ok(rentRequests);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }
}
