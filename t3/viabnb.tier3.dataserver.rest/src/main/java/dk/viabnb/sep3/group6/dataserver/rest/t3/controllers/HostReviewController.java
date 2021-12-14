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

@RestController public class HostReviewController
{
  private HostReviewDAO hostReviewDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();
  private static final Logger LOGGER = LoggerFactory.getLogger(
      HostController.class);

  @Autowired public HostReviewController(HostReviewDAO hostReviewDAO)
  {
    this.hostReviewDAO = hostReviewDAO;
  }

  @GetMapping("/hostreviews/host/{id}") public ResponseEntity<List<HostReview>> getAllHostReviewsByHostId(
      @PathVariable("id") int id)
  {
    try
    {
      List<HostReview> hostReviews = hostReviewDAO.getAllHostReviewsByHostId(
          id);
      LOGGER.info("Request for: " + gson.toJson(hostReviews));
      return ResponseEntity.ok(hostReviews);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @PostMapping("/hostreviews") public ResponseEntity<HostReview> createGuestReview(
      @RequestBody HostReview hostReview)
  {
    if (hostReview == null)
    {
      return ResponseEntity.badRequest().build();
    }
    try
    {
      HostReview createdReview = hostReviewDAO.createHostReview(hostReview);
      if (createdReview == null)
      {
        LOGGER.error("Could not create new HostReview");
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

  @PutMapping("/hostreviews/host/{id}") public ResponseEntity<HostReview> updateHostReview(
      @RequestBody HostReview hostReview, @PathVariable int id)
  {
    try
    {
      List<HostReview> existingHostReviews = hostReviewDAO.getAllHostReviewsByHostId(
          id);

      if (existingHostReviews == null)
      {
        return ResponseEntity.notFound().build();
      }

      LOGGER.info(gson.toJson(hostReviewDAO.updateHostReview(hostReview)));
      return ResponseEntity.ok(hostReviewDAO.updateHostReview(hostReview));
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }
}
