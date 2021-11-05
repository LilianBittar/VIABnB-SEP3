package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.HttpServerErrorException;

@RestController public class ResidenceController
{
  private ResidenceDAO residenceDAO;

  @Autowired public ResidenceController(@Qualifier("residenceJsonDAO") ResidenceDAO residenceDAO)
  {
    this.residenceDAO = residenceDAO;
  }


  @PostMapping("/residence")
  public ResponseEntity<Residence> createResidence(@RequestBody Residence residence)
  {
    Residence newResidence = residenceDAO.createResidence(residence);
    if (newResidence == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<Residence>(newResidence, HttpStatus.OK);
  }
}
