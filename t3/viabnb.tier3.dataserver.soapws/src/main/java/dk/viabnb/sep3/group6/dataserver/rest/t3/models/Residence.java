package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.util.Date;
import java.util.List;

public class Residence
{
  private int id;
  private Address address;
  private String description;
  private String type;
  private double averageRating;
  private boolean isAvailable;
  private double pricePerNight;
  private List<Rule> rules;
  private List<Facility> facilities;
  private String imageURL;
  private Date availableFrom;
  private Date availableTo;

  public Residence(int id, Address address, String description, String type,
      double averageRating, boolean isAvailable, double pricePerNight,
      List<Rule> rules, List<Facility> facilities, String imageURL,
      Date availableFrom, Date availableTo)
  {
    this.id = id;
    this.address = address;
    this.description = description;
    this.type = type;
    this.averageRating = averageRating;
    this.isAvailable = isAvailable;
    this.pricePerNight = pricePerNight;
    this.rules = rules;
    this.facilities = facilities;
    this.imageURL = imageURL;
    this.availableFrom = availableFrom;
    this.availableTo = availableTo;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public Address getAddress()
  {
    return address;
  }

  public void setAddress(Address address)
  {
    this.address = address;
  }

  public String getDescription()
  {
    return description;
  }

  public void setDescription(String description)
  {
    this.description = description;
  }

  public String getType()
  {
    return type;
  }

  public void setType(String type)
  {
    this.type = type;
  }

  public double getAverageRating()
  {
    return averageRating;
  }

  public void setAverageRating(double averageRating)
  {
    this.averageRating = averageRating;
  }

  public boolean isAvailable()
  {
    return isAvailable;
  }

  public void setAvailable(boolean available)
  {
    isAvailable = available;
  }

  public double getPricePerNight()
  {
    return pricePerNight;
  }

  public void setPricePerNight(double pricePerNight)
  {
    this.pricePerNight = pricePerNight;
  }

  public List<Rule> getRules()
  {
    return rules;
  }

  public void setRules(List<Rule> rules)
  {
    this.rules = rules;
  }

  public List<Facility> getFacilities()
  {
    return facilities;
  }

  public void setFacilities(List<Facility> facilities)
  {
    this.facilities = facilities;
  }

  public String getImageURL()
  {
    return imageURL;
  }

  public void setImageURL(String imageURL)
  {
    this.imageURL = imageURL;
  }

  public Date getAvailableFrom()
  {
    return availableFrom;
  }

  public void setAvailableFrom(Date availableFrom)
  {
    this.availableFrom = availableFrom;
  }

  public Date getAvailableTo()
  {
    return availableTo;
  }

  public void setAvailableTo(Date availableTo)
  {
    this.availableTo = availableTo;
  }
}
