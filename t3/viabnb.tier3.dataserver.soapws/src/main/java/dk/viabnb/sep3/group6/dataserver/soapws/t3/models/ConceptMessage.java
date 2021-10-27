package dk.viabnb.sep3.group6.dataserver.soapws.t3.models;

public class ConceptMessage
{
  private int id;
  private String message;

  public ConceptMessage()
  {
  }
  public ConceptMessage(int id, String message)
  {
    this.id = id;
    this.message = message;
  }

  public int getId()
  {
    return id;
  }

  public String getMessage()
  {
    return message;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public void setMessage(String message)
  {
    this.message = message;
  }
}
