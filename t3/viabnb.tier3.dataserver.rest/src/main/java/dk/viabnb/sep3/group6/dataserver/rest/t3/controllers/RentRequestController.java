package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequest;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController
public class RentRequestController {
    private RentRequestDAO rentRequestDAO;

    private static final Logger LOGGER = LoggerFactory.getLogger(
            RentRequestController.class);
    private Gson gson = new Gson();

    @Autowired
    public RentRequestController(RentRequestDAO rentRequestDAO) {
        this.rentRequestDAO = rentRequestDAO;
    }

    @PostMapping("/rentrequests")
    public ResponseEntity<RentRequest> createRentRequest(@RequestBody RentRequest request) {
        LOGGER.info(
                "Request for: createRentRequest received with params: " + gson.toJson(
                        request));
        if (request == null) {
            LOGGER.error("Bad request: request was null");
            return ResponseEntity.badRequest().build();
        }
        try {
            LOGGER.info("Creating rent request...");
            RentRequest createdRentRequest = rentRequestDAO.createNewRentRequest(request);
            if (createdRentRequest == null) {
                LOGGER.error("Rent request could not be created...");
                return ResponseEntity.internalServerError().build();
            }
            LOGGER.info(
                    "New rent request was created: " + gson.toJson(createdRentRequest));
            return ResponseEntity.ok(createdRentRequest);
        } catch (Exception e) {
            LOGGER.error("Rent request could no be created: " + e.getMessage());
            return ResponseEntity.internalServerError().build();
        }
    }

    @GetMapping("/rentrequests")
    public ResponseEntity<List<RentRequest>> getAllRentRequests(
            @RequestParam(required = false) Integer residenceId,
            @RequestParam(required = false) Integer hostId,
            @RequestParam(required = false) Integer guestId,
            @RequestParam(required = false) String status,
            @RequestParam(required = false) Integer viaId) {

        List<RentRequest> requestsToReturn = rentRequestDAO.getAllRentRequests();
        try {
            if (residenceId != null) {
                requestsToReturn.removeIf(request -> request.getId() != residenceId);
            }

            if (hostId != null) {
                requestsToReturn.removeIf(
                        request -> request.getResidence().getHost().getId() != hostId);
            }
            if (guestId != null) {
                requestsToReturn.removeIf(
                        request -> request.getGuest().getId() != guestId);
            }

            if (viaId != null){
                requestsToReturn.removeIf(request -> request.getGuest().getViaId() != viaId);
            }
            if (status != null) {
                requestsToReturn.removeIf(request -> !request.getStatus().name().equals(status));
            }
        } catch (Exception e) {
            LOGGER.error(e.getMessage());
        }
        return ResponseEntity.ok(requestsToReturn);
    }

    @PutMapping("/rentrequests/{id}")
    public ResponseEntity<RentRequest> replaceRentRequest(
            @PathVariable int id, @RequestBody(required = true) RentRequest request) {
        RentRequest existingRentRequest = rentRequestDAO.getRentRequestById(id);
        if (existingRentRequest == null) {
            return ResponseEntity.notFound().build();
        }

        RentRequest updatedRequest = rentRequestDAO.updateRentRequest(request);
        return ResponseEntity.ok(updatedRequest);
    }

    @PatchMapping("/rentrequests/{id}")
    public ResponseEntity<RentRequest> updateRentRequestStatus(
            @RequestBody RentRequest request, @PathVariable("id") int id) {
        RentRequest updateRequest;
        try {
            if (request.getStatus().name().equals("APPROVED")) {
                updateRequest = rentRequestDAO.approveRentRequest(request);
                return ResponseEntity.ok(updateRequest);
            } else if (request.getStatus().name().equals("NOTAPPROVED")) {
                updateRequest = rentRequestDAO.rejectRentRequest(request);
                return ResponseEntity.ok(updateRequest);
            }
            return ResponseEntity.badRequest().build();
        } catch (NoSuchElementException e) {
            e.printStackTrace();
            LOGGER.error(e.getMessage());
            return ResponseEntity.notFound().build();
        }
    }
}
