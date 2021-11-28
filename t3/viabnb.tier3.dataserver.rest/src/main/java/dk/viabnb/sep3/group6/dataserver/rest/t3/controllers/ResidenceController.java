package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
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
//TODO: Change routes to /residences as that is the standard for RESTful collections -mic
@RestController public class ResidenceController
{
  private ResidenceDAO residenceDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();
  private static final Logger LOGGER= LoggerFactory.getLogger(ResidenceController.class);


  @Autowired public ResidenceController(ResidenceDAO residenceDAO)
  {
    this.residenceDAO = residenceDAO;
  }


  @GetMapping("/residence/{id}")
  public ResponseEntity<List<Residence>> getAllResidencesByHostId(@PathVariable int id)
  {
    List<Residence> residences;
   residences = residenceDAO.getAllResidenceByHostId(id);
    if (residences == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(residences, HttpStatus.OK);
  }


  @PostMapping("/residences")
  public ResponseEntity<Residence> createResidence(@RequestBody Residence residence)
  {
    Residence newResidence = residenceDAO.createResidence(residence);
    if (newResidence == null)
    {
      return ResponseEntity.badRequest().build();
    }
    return new ResponseEntity<>(newResidence, HttpStatus.OK);
  }

  /**
   * Handles requests for getting all residences in the system
   * @return HTTP OK with list of all residences if connection to Data source
   *         could be established.
   *         HTTP Internal server error if connection to Data source could not
   *         be established.
   * */
  @GetMapping("/residences")
  public ResponseEntity<List<Residence>> getAll(){
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
}
