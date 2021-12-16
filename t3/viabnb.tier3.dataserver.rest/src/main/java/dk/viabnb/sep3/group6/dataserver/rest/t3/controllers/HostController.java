package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController public class HostController
{
  private static final Logger LOGGER = LoggerFactory.getLogger(
      HostController.class);

  private HostDAO hostDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  @Autowired public HostController(HostDAO hostDAO)
  {
    this.hostDAO = hostDAO;
  }

  @PostMapping("/host") public ResponseEntity<Host> createHost(
      @RequestBody Host host)
  {
    LOGGER.info("Request for: " + gson.toJson(host));

    if (host == null)
    {
      LOGGER.error("host was null");
      return ResponseEntity.badRequest().build();

    }
    try
    {
      Host newHost = hostDAO.registerHost(host);
      if (newHost == null)
      {
        LOGGER.error("DB error");
        return ResponseEntity.internalServerError().build();
      }
      return new ResponseEntity<>(newHost, HttpStatus.OK);

    }
    catch (Exception e)
    {
      LOGGER.error("DB error" + e.getMessage());
      return ResponseEntity.internalServerError().build();
    }

  }

  @GetMapping("/host") public ResponseEntity<Host> getHostByEmail(
      @RequestParam(required = false) String email)
  {

    try
    {
      Host host;
      System.out.println(email);
      host = hostDAO.getHostByEmail(email);
      return ResponseEntity.ok(host);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @GetMapping("/host/{id}") public ResponseEntity<Host> getHostById(
      @PathVariable int id)
  {
    Host host;
    try
    {
      host = hostDAO.getHostById(id);
      return new ResponseEntity<>(host, HttpStatus.OK);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @GetMapping("/hosts/notApproved") public ResponseEntity<List<Host>> getAllNotApprovedHosts()
  {
    List<Host> hostsToReturn;
    hostsToReturn = hostDAO.getAllNotApprovedHosts();
    if (hostsToReturn == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(hostsToReturn, HttpStatus.OK);
  }

  @RequestMapping(value = "/hosts/{id}/approval", produces = "application/json", method = RequestMethod.PATCH) public ResponseEntity<Host> updateHostStatus(
      @RequestBody Host host, @PathVariable("id") int id)
  {
    Host updatedHost = null;
    try
    {
      if (host.isApprovedHost())
      {
        updatedHost = hostDAO.approveHost(host);
        return ResponseEntity.ok(updatedHost);
      }
      else if (!host.isApprovedHost())
      {
        updatedHost = hostDAO.rejectHost(host);
        return ResponseEntity.ok(updatedHost);
      }
      return ResponseEntity.badRequest().build();
    }
    catch (NoSuchElementException e)
    {
      e.printStackTrace();
      LOGGER.error("Failed to execute update" + e.getMessage());
      return ResponseEntity.notFound().build();
    }
  }
}
