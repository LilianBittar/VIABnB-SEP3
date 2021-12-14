package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility.FacilityDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Facility;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController public class FacilityController
{
  private FacilityDAO facilityDAO;

  @Autowired public FacilityController(FacilityDAO facilityDAO)
  {
    this.facilityDAO = facilityDAO;
  }

  @PostMapping("/facility/{facilityId}/{residenceId}") public ResponseEntity<Facility> createFacility(
      @RequestBody Facility facility,
      @PathVariable("facilityId") int facilityId,
      @PathVariable("residenceId") int residenceId)
  {
    Facility newFacility = facilityDAO.createResidenceFacility(facility,
        residenceId);
    try
    {
      if (newFacility == null)
      {
        return ResponseEntity.internalServerError().build();
      }
      return new ResponseEntity<>(newFacility, HttpStatus.OK);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @GetMapping("/facilities") public ResponseEntity<List<Facility>> getAllFacilities()
  {
    List<Facility> facilityListToReturn = facilityDAO.getAllFacilities();
    try
    {
      if (facilityListToReturn == null)
      {
        return ResponseEntity.internalServerError().build();
      }
      return new ResponseEntity<>(facilityListToReturn, HttpStatus.OK);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @GetMapping("/facility/{id}") public ResponseEntity<Facility> getFacilityById(
      @PathVariable int id)
  {
    Facility facilityToReturn = facilityDAO.getFacilityById(id);
    try
    {
      if (facilityToReturn == null)
      {
        return ResponseEntity.internalServerError().build();
      }
      return new ResponseEntity<>(facilityToReturn, HttpStatus.OK);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @DeleteMapping("/residencefacilities/{facilityId}/{residenceId}") public ResponseEntity<Void> deleteResidenceFacility(
      @PathVariable("facilityId") int facilityId,
      @PathVariable("residenceId") int residenceId)
  {
    try
    {
      facilityDAO.deleteResidenceFacility(facilityId, residenceId);
      return new ResponseEntity<Void>(HttpStatus.OK);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }
}
