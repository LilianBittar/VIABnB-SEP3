package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.sun.jdi.event.ExceptionEvent;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequest;
import org.apache.coyote.Response;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

public class RentRequestController {
    private RentRequestDAO rentRequestDAO;

    @Autowired
    public RentRequestController(RentRequestDAO rentRequestDAO) {
        this.rentRequestDAO = rentRequestDAO;
    }

    @PostMapping("/rentrequests")
    public ResponseEntity<RentRequest> createRentRequest(@RequestBody RentRequest request) {
        if (request == null) {
            return ResponseEntity.badRequest().build();
        }
        try {
            RentRequest createdRentRequest = rentRequestDAO.create(request);
            return ResponseEntity.ok(createdRentRequest);
        } catch (Exception e) {
            return ResponseEntity.internalServerError().build();
        }
    }


    @GetMapping("/rentrequests")
    public ResponseEntity<List<RentRequest>> getAllRentRequests(@RequestParam(required = false) Integer residenceId,
                                                                @RequestParam(required = false) Integer hostId,
                                                                @RequestParam(required = false) Integer guestId) {

        List<RentRequest> requestsToReturn = rentRequestDAO.getAll();
        if (residenceId != null) {
            requestsToReturn.forEach((request) -> {
                if (request.getResidence().getId() != residenceId.intValue()) {
                    requestsToReturn.remove(request);
                }
            });
        }

        //TODO: iterate requests and remove all where request.getHost().getId() != hostId.
        if (guestId != null) {
            requestsToReturn.forEach((request) -> {
                if (request.getGuest().getId() != guestId.intValue()) {
                    requestsToReturn.remove(request);
                }
            });
        }

        return ResponseEntity.ok(requestsToReturn);
    }


    @GetMapping("/rentrequests/{id}")
    public ResponseEntity<RentRequest> getRentRequest(@PathVariable int id) {
        RentRequest existingRequest = rentRequestDAO.getById(id);
        if (existingRequest == null){
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(existingRequest);
    }

    @PutMapping("/rentrequests/{id}")
    public ResponseEntity<RentRequest> replaceRentRequest(@PathVariable int id,@RequestBody(required = true) RentRequest request){
        RentRequest existingRentRequest = rentRequestDAO.getById(id);
        RentRequest updatedRequest = null;
        if (existingRentRequest == null){
            updatedRequest = rentRequestDAO.create(request);
            return ResponseEntity.ok(updatedRequest);
        }

        updatedRequest = rentRequestDAO.update(request);
        return ResponseEntity.ok(updatedRequest);
    }

}
