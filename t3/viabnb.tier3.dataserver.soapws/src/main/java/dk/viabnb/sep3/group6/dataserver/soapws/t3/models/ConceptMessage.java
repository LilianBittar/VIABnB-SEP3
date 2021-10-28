package dk.viabnb.sep3.group6.dataserver.soapws.t3.models;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
public class ConceptMessage
{
  @XmlElement
  private int id;
  @XmlElement
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
