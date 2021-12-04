package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview.GuestReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
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

  @GetMapping("/guestreviews/{id}")
  public ResponseEntity<List<GuestReview>> getAllGuestReviews(@PathVariable("id") int id)
  {
    List<GuestReview> guestReviews = guestReviewDAO.getAllGuestReviewsByGuestId(id);
    LOGGER.info("Request for: " + gson.toJson(guestReviews));
    return ResponseEntity.ok(guestReviews);
  }

  @PostMapping("/guestreviews")
  public ResponseEntity<GuestReview> createGuestReview(@RequestBody GuestReview guestReview)
  {
    throw new NotImplementedException();
  }
}
