package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview.ResidenceReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.ResidenceReview;
import org.apache.coyote.Response;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;

public class ResidenceReviewController {
    private ResidenceReviewDAO residenceReviewDAO;
    private final Logger LOGGER = LoggerFactory.getLogger(ResidenceReviewController.class);

    @Autowired
    public ResidenceReviewController(ResidenceReviewDAO residenceReviewDAO) {
        this.residenceReviewDAO = residenceReviewDAO;
    }


    @PutMapping("/residencereviews/{id}")
    public ResponseEntity<ResidenceReview> update(@PathVariable int id, @RequestBody ResidenceReview residenceReview) {
        if (residenceReview != null || id <= 0) {
            return ResponseEntity.badRequest().build();
        }
        try {
            ResidenceReview updatedReview = residenceReviewDAO.update(id, residenceReview);
            return ResponseEntity.ok(updatedReview);
        } catch (IllegalStateException e) {
            LOGGER.error(e.getMessage());
            return ResponseEntity.internalServerError().build();
        }

    }
}
