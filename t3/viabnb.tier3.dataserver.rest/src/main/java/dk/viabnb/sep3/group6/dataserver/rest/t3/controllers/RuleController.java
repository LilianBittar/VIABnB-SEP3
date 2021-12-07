package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule.RuleDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController public class RuleController
{
  private RuleDAO ruleDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  public RuleController(RuleDAO ruleDAO)
  {
    this.ruleDAO = ruleDAO;
  }

  @GetMapping("/rules") public ResponseEntity<List<Rule>> getAllRules()
  {
    List<Rule> ruleListToReturn = ruleDAO.getAllRules();
    if (ruleListToReturn == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(ruleListToReturn, HttpStatus.OK);
  }

  @PostMapping("/rule") public ResponseEntity<Rule> createRule(
      @RequestBody Rule rule)
  {
    Rule newRule = ruleDAO.createRule(rule);
    if (newRule == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(newRule, HttpStatus.OK);
  }

  @PatchMapping("/rule/{description}/{residenceId}")
  public ResponseEntity<Rule> updateRule(@RequestBody Rule rule, @PathVariable("description") String description, @PathVariable("residenceId") int residenceId)
  {
    try
    {
      rule = ruleDAO.updateRule(rule);
      return ResponseEntity.ok(rule);
    }
    catch (Exception e)
    {
      return ResponseEntity.badRequest().build();
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
