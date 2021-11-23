package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration.AdministrationDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class AdministrationController
{
  private AdministrationDAO administrationDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  @Autowired
  public AdministrationController()
  {

  }
}
