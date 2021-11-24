package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class Address
{
  private int id;
  private String streetName;
  private String houseNumber;
  private String streetNumber;
  private City city;

  public Address(int id, String streetName, String houseNumber,
      String streetNumber, City city)
  {
    this.id = id;
    this.streetName = streetName;
    this.houseNumber = houseNumber;
    this.streetNumber = streetNumber;
    this.city = city;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public String getStreetName()
  {
    return streetName;
  }

  public void setStreetName(String streetName)
  {
    this.streetName = streetName;
  }

  public String getHouseNumber()
  {
    return houseNumber;
  }

  public void setHouseNumber(String houseNumber)
  {
    this.houseNumber = houseNumber;
  }

  public String getStreetNumber()
  {
    return streetNumber;
  }

  public void setStreetNumber(String streetNumber)
  {
    this.streetNumber = streetNumber;
  }

  public City getCity()
  {
    return city;
  }

  public void setCity(City city)
  {
    this.city = city;
  }

  @Override public String toString()
  {
    return "Address{" + "id=" + id + ", streetName='" + streetName + '\''
        + ", houseNumber='" + houseNumber + '\'' + ", streetNumber='"
        + streetNumber + '\'' + ", city=" + city.toString() + '}';
  }
}
