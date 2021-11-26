package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration.AdministrationDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Administrator;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController public class AdministrationController
{
  private AdministrationDAO administrationDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  @Autowired public AdministrationController(
      AdministrationDAO administrationDAO)
  {
    this.administrationDAO = administrationDAO;
  }

  @GetMapping("/admin") public ResponseEntity<Administrator> getAdminByEmail(
      @RequestParam(required = false) String email)
  {
    Administrator adminToReturn = administrationDAO.getAdministratorByEmail(
        email);
    if (adminToReturn == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(adminToReturn, HttpStatus.OK);
  }

  @GetMapping("/admins") public ResponseEntity<List<Administrator>> getAllAdmins()
  {
    List<Administrator> administratorListToReturn = administrationDAO.getAllAdministrators();
    if (administratorListToReturn == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(administratorListToReturn, HttpStatus.OK);
  }
}
