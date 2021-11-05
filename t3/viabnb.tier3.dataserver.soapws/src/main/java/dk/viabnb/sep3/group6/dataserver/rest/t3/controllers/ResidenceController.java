package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RestController;

@RestController public class ResidenceController
{
  private ResidenceDAO residenceDAO;

  @Autowired public ResidenceController(ResidenceDAO residenceDAO)
  {
    this.residenceDAO = residenceDAO;
  }
}
