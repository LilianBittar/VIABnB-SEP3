package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class Rule
{
  private String description;
  private int residenceId;

  public Rule(String description, int residenceId)
  {
    this.description = description;
    this.residenceId = residenceId;
  }

  public String getDescription()
  {
    return description;
  }

  public void setDescription(String description)
  {
    this.description = description;
  }

  public int getResidenceId()
  {
    return residenceId;
  }

  public void setResidenceId(int residenceId)
  {
    this.residenceId = residenceId;
  }

  @Override public String toString()
  {
    return "Rule{" + "description='" + description + '\'' + ", residenceId="
        + residenceId + '}';
  }
}
