package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class Facility
{
  private int id;
  private int name;

  public Facility(int id, int name)
  {
    this.id = id;
    this.name = name;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public int getName()
  {
    return name;
  }

  public void setName(int name)
  {
    this.name = name;
  }
}
