package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.hostreview.HostReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
public class HostReviewController {
    private HostReviewDAO hostReviewDAO;
    private Gson gson = new GsonBuilder().serializeNulls().create();
    private static final Logger LOGGER = LoggerFactory.getLogger(HostController.class);

    @Autowired
    public HostReviewController(HostReviewDAO hostReviewDAO)
    {
        this.hostReviewDAO = hostReviewDAO;
    }

    @GetMapping("/hostreviews/{id}")
    public ResponseEntity<List<HostReview>> getAllHostReviews(@PathVariable("id") int id)
    {
        List<HostReview> hostReviews = hostReviewDAO.getAllHostReviewsByHostId(id);
        LOGGER.info("Request for: " + gson.toJson(hostReviews));
        return ResponseEntity.ok(hostReviews);
    }

    @PostMapping("/hostreviews")
    public ResponseEntity<HostReview> createGuestReview(@RequestBody HostReview hostReview)
    {
        if (hostReview == null) {
            return ResponseEntity.badRequest().build();
        }
        try {
            HostReview createdReview = hostReviewDAO.createHostReview(hostReview);
            if (createdReview == null){
                LOGGER.error("Could not create new HostReview");
                return ResponseEntity.internalServerError().build();
            }
            return ResponseEntity.ok(createdReview);
        } catch (Exception e) {
            LOGGER.error(e.getMessage());
            return ResponseEntity.internalServerError().build();
        }
    }

    @PutMapping("/hostreviews/{id}")
    public ResponseEntity<HostReview> UpdateHostReview(@RequestBody HostReview hostReview, @PathVariable int id) {
        try {
            List<HostReview> existingHostReviews = hostReviewDAO.getAllHostReviewsByHostId(id);

            if (existingHostReviews == null) {
                return ResponseEntity.notFound().build();
            }

            boolean found = false;
            for (HostReview review : existingHostReviews) {
                if (review.getViaId() == hostReview.getViaId()) {
                    found = true;
                    break;
                }
            }
            if (!found) {
                return ResponseEntity.notFound().build();
            }

            hostReviewDAO.updateHostReview(hostReview);

        } catch (Exception e) {
            LOGGER.error(e.getMessage());
            return ResponseEntity.internalServerError().build();
        }

        return null;
    }
}
