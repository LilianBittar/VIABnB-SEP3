package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry.CityDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController public class CityController
{
  private CityDAO cityDAO;
  private final Logger LOGGER = LoggerFactory.getLogger(CityController.class);

  @Autowired public CityController(CityDAO cityDAO)
  {
    this.cityDAO = cityDAO;
  }

  @GetMapping("/cities") public ResponseEntity<List<City>> getAll()
  {
    try
    {
      LOGGER.info("GET request received for /cities");
      return ResponseEntity.ok(cityDAO.getAll());
    }
    catch (Exception e)
    {
      e.printStackTrace();
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @PostMapping("/cities") public ResponseEntity<City> create(
      @RequestBody City city)
  {
    if (city == null)
    {
      return ResponseEntity.badRequest().build();
    }
    try
    {
      return ResponseEntity.ok(cityDAO.createNewCity(city));
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }
}
