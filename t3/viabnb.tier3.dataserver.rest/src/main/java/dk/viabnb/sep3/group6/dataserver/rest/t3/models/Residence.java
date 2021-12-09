package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.time.LocalDate;
import java.util.Date;
import java.util.List;

public class Residence
{
  private int id;
  private Address address;
  private String description;
  private String type;
  @JsonProperty("isAvailable")
  private boolean isAvailable;
  private double pricePerNight;
  private List<Rule> rules;
  private List<Facility> facilities;
  private String imageUrl;
  private LocalDate availableFrom;
  private LocalDate availableTo;
  private int maxNumberOfGuests;
  private Host host;
  private List<ResidenceReview> residenceReviews;

  public Residence(int id, Address address, String description, String type,
                   boolean isAvailable, double pricePerNight, List<Rule> rules,
                   List<Facility> facilities, String imageUrl, LocalDate availableFrom,
                   LocalDate availableTo, int maxNumberOfGuests, Host host,
                   List<ResidenceReview> residenceReviews)
  {
    this.id = id;
    this.address = address;
    this.description = description;
    this.type = type;
    this.isAvailable = isAvailable;
    this.pricePerNight = pricePerNight;
    this.rules = rules;
    this.facilities = facilities;
    this.imageUrl = imageUrl;
    this.availableFrom = availableFrom;
    this.availableTo = availableTo;
    this.maxNumberOfGuests = maxNumberOfGuests;
    this.host = host;
    this.residenceReviews = residenceReviews;
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

  public String getImageUrl()
  {
    return imageUrl;
  }

  public void setImageUrl(String imageUrl)
  {
    this.imageUrl = imageUrl;
  }

  public LocalDate getAvailableFrom()
  {
    return availableFrom;
  }

  public void setAvailableFrom(LocalDate availableFrom)
  {
    this.availableFrom = availableFrom;
  }

  public LocalDate getAvailableTo()
  {
    return availableTo;
  }

  public void setAvailableTo(LocalDate availableTo)
  {
    this.availableTo = availableTo;
  }

  public int getMaxNumberOfGuests()
  {
    return maxNumberOfGuests;
  }

  public void setMaxNumberOfGuests(int maxNumberOfGuests)
  {
    this.maxNumberOfGuests = maxNumberOfGuests;
  }

  public Host getHost()
  {
    return host;
  }

  public void setHost(Host host)
  {
    this.host = host;
  }

  public List<ResidenceReview> getResidenceReviews()
  {
    return residenceReviews;
  }

  public void setResidenceReviews(List<ResidenceReview> residenceReviews)
  {
    this.residenceReviews = residenceReviews;
  }

  @Override public String toString()
  {
    return "Residence{" + "id=" + id + ", address=" + address
        + ", description='" + description + '\'' + ", type='" + type + '\''
        + ", isAvailable=" + isAvailable
        + ", pricePerNight=" + pricePerNight + ", rules=" + rules
        + ", facilities=" + facilities + ", imageURL='" + imageUrl + '\''
        + ", availableFrom=" + availableFrom + ", availableTo=" + availableTo
        + '}';
  }
}
