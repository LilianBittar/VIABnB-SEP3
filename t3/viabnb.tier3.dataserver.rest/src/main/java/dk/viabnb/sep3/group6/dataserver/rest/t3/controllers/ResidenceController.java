package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview.ResidenceReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.ResidenceReview;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.HttpServerErrorException;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

//TODO: Change routes to /residences as that is the standard for RESTful collections -mic
@RestController
public class ResidenceController {
    private ResidenceDAO residenceDAO;
    private ResidenceReviewDAO residenceReviewDAO;
    private Gson gson = new GsonBuilder().serializeNulls().create();
    private static final Logger LOGGER = LoggerFactory.getLogger(ResidenceController.class);


    @Autowired
    public ResidenceController(ResidenceDAO residenceDAO, ResidenceReviewDAO residenceReviewDAO) {
        this.residenceDAO = residenceDAO;
        this.residenceReviewDAO = residenceReviewDAO;
    }


    //TODO: Move this to host controller maybe (/hosts/residences)? Or maybe the getAll method with a query param.
    // e.g. /residence/1 SHOULD mean give me the residence with the id of 1.  -mic
    @GetMapping("/residence/{id}")
    public ResponseEntity<List<Residence>> getAllResidencesByHostId(@PathVariable int id) {
        List<Residence> residences;
        residences = residenceDAO.getAllResidenceByHostId(id);
        if (residences == null) {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(residences, HttpStatus.OK);
    }


    @GetMapping("/residences/{id}")
    public ResponseEntity<Residence> getById(@PathVariable int id) {
        try {
            Residence residence = residenceDAO.getByResidenceId(id);
            return ResponseEntity.ok(residence);
        } catch (IllegalStateException e) {
            return ResponseEntity.internalServerError().build();
        }

    }

    @PostMapping("/residences")
    public ResponseEntity<Residence> createResidence(@RequestBody Residence residence) {
        Residence newResidence = residenceDAO.createResidence(residence);
        if (newResidence == null) {
            return ResponseEntity.badRequest().build();
        }
        return new ResponseEntity<>(newResidence, HttpStatus.OK);
    }

    /**
     * Handles requests for getting all residences in the system
     *
     * @return HTTP OK with list of all residences if connection to Data source
     * could be established.
     * HTTP Internal server error if connection to Data source could not
     * be established.
     */
    @GetMapping("/residences")
    public ResponseEntity<List<Residence>> getAll() {
        try {
            LOGGER.info("Request for all residences received");
            List<Residence> residences = residenceDAO.getAllResidences();
            LOGGER.info("Returning: " + gson.toJson(residences));
            return ResponseEntity.ok(residences);
        } catch (Exception e) {
            LOGGER.error("Connection failed " + e.getMessage());
            return ResponseEntity.internalServerError().build();
        }
    }

    @PutMapping("/residences/{id}")
    public ResponseEntity<Residence> UpdateAvailabilityPeriod(@RequestBody Residence residence, @PathVariable int id) {

        try {
            Residence existingResidence = residenceDAO.getByResidenceId(id);

            if (existingResidence == null) {
                return ResponseEntity.notFound().build();
            }

            residenceDAO.UpdateAvailabilityPeriod(residence);

        } catch (Exception e) {
            LOGGER.error(e.getMessage());
            return ResponseEntity.internalServerError().build();
        }

        return null;
    }

    @PostMapping("/residences/{residenceId}/residencereviews")
    public ResponseEntity<ResidenceReview> create(@PathVariable int residenceId, @RequestBody ResidenceReview residenceReview) {
        if (residenceReview == null || residenceId <= 0) {
            return ResponseEntity.badRequest().build();
        }
        try {
            Residence residence = residenceDAO.getByResidenceId(residenceId);
            ResidenceReview createdReview = residenceReviewDAO.create(residence, residenceReview);
            return ResponseEntity.ok(createdReview);
        } catch (Exception e) {
            LOGGER.error(e.getMessage());
            return ResponseEntity.internalServerError().build();
        }
    }

    // Might have to add /{viaid} after /residencereviews, but might be too long endpoint / bad design? (PK of a review is a composite key)
    @PutMapping("/residences/{residenceId}/residencereviews")
    public ResponseEntity<ResidenceReview> update(@PathVariable int residenceId, @RequestBody ResidenceReview residenceReview) {
        if (residenceReview != null || residenceId <= 0) {
            return ResponseEntity.badRequest().build();
        }
        try {
            ResidenceReview updatedReview = residenceReviewDAO.update(residenceId, residenceReview);
            return ResponseEntity.ok(updatedReview);
        } catch (IllegalStateException e) {
            LOGGER.error(e.getMessage());
            return ResponseEntity.internalServerError().build();
        }

    }

}
