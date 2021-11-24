package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class Rule
{
  private String description;

  public Rule(String description)
  {
    this.description = description;
  }

  public String getDescription()
  {
    return description;
  }

  public void setDescription(String description)
  {
    this.description = description;
  }

  @Override public String toString()
  {
    return "Rule{" + "description='" + description + '\'' + '}';
  }
}
