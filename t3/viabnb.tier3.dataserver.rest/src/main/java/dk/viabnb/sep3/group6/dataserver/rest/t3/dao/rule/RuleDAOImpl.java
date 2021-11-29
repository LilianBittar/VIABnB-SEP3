package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class RuleDAOImpl extends BaseDao implements RuleDAO
{
  @Override public Rule createRule(Rule rule)
  {
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("INSERT INTO rule(ruledescription, residenceid) VALUES (?,?)");
      stm.setString(1, rule.getDescription());
      stm.setInt(2, rule.getResidenceId());
      stm.executeUpdate();
      connection.commit();
      return rule;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Rule> getAllRules()
  {
    List<Rule> ruleListToReturn = new ArrayList<>();
    try(Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement
          ("SELECT * FROM rule JOIN residence r ON r.residenceid = rule.residenceid");
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        Rule rule = new Rule
            (
                result.getString("ruledescription"),
                result.getInt("residenceid")
            );
        ruleListToReturn.add(rule);
      }
      return ruleListToReturn;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
