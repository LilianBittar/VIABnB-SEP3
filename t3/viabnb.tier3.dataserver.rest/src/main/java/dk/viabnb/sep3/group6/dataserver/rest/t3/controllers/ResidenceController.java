package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.HttpServerErrorException;

import java.util.ArrayList;
import java.util.List;

@RestController public class ResidenceController
{
  private ResidenceDAO residenceDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  @Autowired public ResidenceController(@Qualifier("residenceJsonDAO") ResidenceDAO residenceDAO)
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


  @PostMapping("/residence")
  public ResponseEntity<Residence> createResidence(@RequestBody Residence residence)
  {
    Residence newResidence = residenceDAO.createResidence(residence);
    if (newResidence == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(newResidence, HttpStatus.OK);
  }
}
