package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule.RuleDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

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
}
