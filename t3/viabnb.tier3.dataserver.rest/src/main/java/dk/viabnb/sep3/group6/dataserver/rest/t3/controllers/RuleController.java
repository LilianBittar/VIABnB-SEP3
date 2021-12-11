package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule.RuleDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController public class RuleController
{
  private RuleDAO ruleDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();
  private static final Logger LOGGER = LoggerFactory.getLogger(
      RuleController.class);

  public RuleController(RuleDAO ruleDAO)
  {
    this.ruleDAO = ruleDAO;
  }

  @PostMapping("/rule/{residenceId}")
  public ResponseEntity<Rule> createResidenceRule(@RequestBody Rule rule, @PathVariable("residenceId") int residenceId)
  {
    try
    {
      rule = ruleDAO.createResidenceRule(rule);
      return ResponseEntity.ok(rule);
    }
    catch (Exception e)
    {
      return ResponseEntity.internalServerError().build();
    }
  }

  @GetMapping("/rule/{residenceId}")
  public ResponseEntity<List<Rule>> getAllResidenceRules(@PathVariable("residenceId") int residenceId)
  {
    List<Rule> ruleList = ruleDAO.getAllRulesByResidenceId(residenceId);
    if (ruleList == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return ResponseEntity.ok(ruleList);
  }

  @PatchMapping("/rule/{description}/{residenceId}")
  public ResponseEntity<Rule> updateRule(@RequestBody Rule rule, @PathVariable("description") String description, @PathVariable("residenceId") int residenceId)
  {
    try
    {
      rule = ruleDAO.updateRule(rule, description);
      LOGGER.info(gson.toJson(rule));
      return ResponseEntity.ok(rule);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @DeleteMapping("/rule/{description}/{residenceId}")
  public ResponseEntity<Void> deleteRule(@PathVariable("description") String description, @PathVariable("residenceId") int residenceId)
  {
    try
    {
      ruleDAO.deleteRule(description, residenceId);
      return new ResponseEntity<>(HttpStatus.OK);
    }
    catch (Exception e)
    {
      return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
    }
  }
}
