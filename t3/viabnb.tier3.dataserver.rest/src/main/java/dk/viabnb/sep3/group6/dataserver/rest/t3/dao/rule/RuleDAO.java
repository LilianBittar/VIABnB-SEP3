package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;

import java.util.List;

public interface RuleDAO
{
  /**
   * Create a new Rule object and store it in the database
   *
   * @param rule The new Rule object
   * @return The newly created Rule object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Rule createResidenceRule(Rule rule);
  /**
   * Query a list of Rule objects based on the given parameter
   *
   * @param residenceId The targeted Residence's id
   * @return a list of Rule objects
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Rule> getAllRulesByResidenceId(int residenceId);
  /**
   * Update an existing Rule object and store it in the database
   *
   * @param rule        The new Rule object
   * @param description The Rule's Description
   * @return the newly updated Rule object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Rule updateRule(Rule rule, String description);
  /**
   * Delete a Rule object from the database
   *
   * @param description The targeted Rule's description for deletion
   * @param residenceId The targeted Rule's residence id for deletion
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  void deleteRule(String description, int residenceId);
}
