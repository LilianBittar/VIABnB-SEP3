package dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.models;

public class ConceptMessage
{
  private int id;
  private String message;

  public ConceptMessage(int id, String message)
  {
    this.id = id;
    this.message = message;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public String getMessage()
  {
    return message;
  }

  public void setMessage(String message)
  {
    this.message = message;
  }
}
