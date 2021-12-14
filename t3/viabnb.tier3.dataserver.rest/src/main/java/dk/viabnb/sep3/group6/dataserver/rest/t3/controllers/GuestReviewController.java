package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview.GuestReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController public class GuestReviewController
{
  private GuestReviewDAO guestReviewDAO;
  private static final Logger LOGGER = LoggerFactory.getLogger(
      GuestController.class);

  @Autowired public GuestReviewController(GuestReviewDAO guestReviewDAO)
  {
    this.guestReviewDAO = guestReviewDAO;
  }

  @GetMapping("/guestreviews/guest/{id}") public ResponseEntity<List<GuestReview>> getAllGuestReviewsByGuestId(
      @PathVariable("id") int id)
  {
    try
    {
      List<GuestReview> guestReviews = guestReviewDAO.getAllGuestReviewsByGuestId(
          id);
      return ResponseEntity.ok(guestReviews);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @PostMapping("/guestreviews") public ResponseEntity<GuestReview> createGuestReview(
      @RequestBody GuestReview guestReview)
  {

    if (guestReview == null)
    {
      return ResponseEntity.badRequest().build();
    }
    try
    {
      GuestReview createdReview = guestReviewDAO.createGuestReview(guestReview);
      if (createdReview == null)
      {
        LOGGER.error("Could not create new GuestReview");
        return ResponseEntity.internalServerError().build();
      }
      return ResponseEntity.ok(createdReview);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @PutMapping("/guestreviews/guest/{id}") public ResponseEntity<GuestReview> updateGuestReview(
      @RequestBody GuestReview guestReview, @PathVariable int id)
  {
    try
    {
      List<GuestReview> existingGuestReviews = guestReviewDAO.getAllGuestReviewsByHostId(
          id);

      if (existingGuestReviews == null)
      {
        return ResponseEntity.notFound().build();
      }

      return ResponseEntity.ok(guestReviewDAO.updateGuestReview(guestReview));

    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }
}
