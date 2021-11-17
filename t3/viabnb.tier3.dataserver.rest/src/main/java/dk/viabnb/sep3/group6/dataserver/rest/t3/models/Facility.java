package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class Facility
{
  private int id;
  private String name;

  public Facility(int id, String name)
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

  public String getName()
  {
    return name;
  }

  public void setName(String name)
  {
    this.name = name;
  }

  @Override public String toString()
  {
    return "Facility{" + "id=" + id + ", name='" + name + '\'' + '}';
  }
}
