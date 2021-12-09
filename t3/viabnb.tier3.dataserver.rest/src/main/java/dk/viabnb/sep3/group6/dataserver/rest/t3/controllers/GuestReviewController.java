package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview.GuestReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;
import org.apache.commons.lang3.NotImplementedException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class GuestReviewController
{
  private GuestReviewDAO guestReviewDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();
  private static final Logger LOGGER = LoggerFactory.getLogger(
      GuestController.class);

  @Autowired
  public GuestReviewController(GuestReviewDAO guestReviewDAO)
  {
    this.guestReviewDAO = guestReviewDAO;
  }

  /*@GetMapping("/guestreviews/{id}")
  public ResponseEntity<List<GuestReview>> getAllGuestReviews(@PathVariable("id") int id)
  {
    List<GuestReview> guestReviews = guestReviewDAO.getAllGuestReviewsByHostId(id);
    LOGGER.info("Request for: " + gson.toJson(guestReviews));
    return ResponseEntity.ok(guestReviews);
  }*/
  @GetMapping("/guestreviews/{id}")
  public ResponseEntity<List<GuestReview>> getAllGuestReviewsByGuestId(@PathVariable("id") int id)
  {
    List<GuestReview> guestReviews = guestReviewDAO.getAllGuestReviewsByGuestId(id);
    LOGGER.info("Request for: " + gson.toJson(guestReviews));
    return ResponseEntity.ok(guestReviews);
  }

  @PostMapping("/guestreviews")
  public ResponseEntity<GuestReview> createGuestReview(@RequestBody GuestReview guestReview)
  {

    if (guestReview == null) {
      return ResponseEntity.badRequest().build();
    }
    try {
      GuestReview createdReview = guestReviewDAO.createGuestReview(guestReview);
      if (createdReview == null){
        LOGGER.error("Could not create new GuestReview");
        return ResponseEntity.internalServerError().build();
      }
      return ResponseEntity.ok(createdReview);
    } catch (Exception e) {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @PutMapping("/guestreviews/{id}")
  public ResponseEntity<GuestReview> UpdateGuestReview(@RequestBody GuestReview guestReview, @PathVariable int id) {
    try {
      List<GuestReview> existingGuestReviews = guestReviewDAO.getAllGuestReviewsByHostId(id);

      if (existingGuestReviews == null) {
        return ResponseEntity.notFound().build();
      }

      boolean found = false;
      for (GuestReview review : existingGuestReviews) {
        if (review.getHostId() == guestReview.getHostId()) {
          found = true;
          break;
        }
      }
      if (!found) {
        return ResponseEntity.notFound().build();
      }

      guestReviewDAO.updateGuestReview(guestReview);

    } catch (Exception e) {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }

    return null;
  }
}
