package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;

import java.util.List;

public interface RuleDAO
{
  Rule createRule(Rule rule);
  List<Rule> getAllRules();
}
