package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility.FacilityDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Facility;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController public class FacilityController
{
  private FacilityDAO facilityDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  public FacilityController(FacilityDAO facilityDAO)
  {
    this.facilityDAO = facilityDAO;
  }

  @PostMapping("/facility") public ResponseEntity<Facility> createFacility(
      @RequestBody Facility facility)
  {
    Facility newFacility = facilityDAO.createFacility(facility);
    if (newFacility == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(newFacility, HttpStatus.OK);
  }

  @GetMapping("/facilities") public ResponseEntity<List<Facility>> getAllFacilities()
  {
    List<Facility> facilityListToReturn = facilityDAO.getAllFacilities();
    if (facilityListToReturn == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(facilityListToReturn, HttpStatus.OK);
  }

  @GetMapping("/facility/{id}") public ResponseEntity<Facility> getFacilityById(
      @PathVariable int id)
  {
    Facility facilityToReturn = facilityDAO.getFacilityById(id);
    if (facilityToReturn == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(facilityToReturn, HttpStatus.OK);
  }
}