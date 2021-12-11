package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;

import java.util.List;

public interface RuleDAO
{
  /**
   * Create a new rule object
   * @param rule The new rule
   * @return The newly created rule object
   *
   * @throws IllegalStateException if can't connect to database
   * */
  Rule createResidenceRule(Rule rule);
  /**
   * Handle a query that returns a list of all the rules ibased on the given parameter
   * @return a list of rule objects
   * @param residenceId The targeted residence's id
   *
   * @throws IllegalStateException if can't connect to database
   * */
  List<Rule> getAllRulesByResidenceId(int residenceId);
  /**
   * Update an existing rule in the system by identify its residence and replace that residence's rule info
   * @param rule The new rule witch will have the new arguments
   * @param description
   * @return the newly updated rule
   *
   * @throws IllegalStateException if cant connect to database
   * */
  Rule updateRule(Rule rule, String description);
  /**
   * Delete rule from the system
   * @param description The targeted rule description for deletion
   * @param residenceId The targeted rule residence id for deletion
   *
   * @throws IllegalStateException if can't connect to database
   * */
  void deleteRule(String description, int residenceId);
}
