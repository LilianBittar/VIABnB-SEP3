package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility.FacilityDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ResidenceFacilityController
{
  private FacilityDAO facilityDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  @Autowired
  public ResidenceFacilityController(FacilityDAO facilityDAO)
  {
    this.facilityDAO = facilityDAO;
  }

  @DeleteMapping("/residencefacilities/{facilityId}/{residenceId}")
  public ResponseEntity<Void> deleteResidenceFacility(@PathVariable("facilityId") int facilityId, @PathVariable("residenceId") int residenceId)
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
