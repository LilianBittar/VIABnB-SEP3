package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class Address
{
  private int id;
  private String streetName;
  private String houseNumber;
  private String cityName;
  private String streetNumber;
  private int zipCode;

  public Address(int id, String streetName, String houseNumber, String cityName,
      String streetNumber, int zipCode)
  {
    this.id = id;
    this.streetName = streetName;
    this.houseNumber = houseNumber;
    this.cityName = cityName;
    this.streetNumber = streetNumber;
    this.zipCode = zipCode;
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

  public String getCityName()
  {
    return cityName;
  }

  public void setCityName(String cityName)
  {
    this.cityName = cityName;
  }

  public String getStreetNumber()
  {
    return streetNumber;
  }

  public void setStreetNumber(String streetNumber)
  {
    this.streetNumber = streetNumber;
  }

  public int getZipCode()
  {
    return zipCode;
  }

  public void setZipCode(int zipCode)
  {
    this.zipCode = zipCode;
  }

  @Override public String toString()
  {
    return "Address{" + "id=" + id + ", streetName='" + streetName + '\''
        + ", houseNumber='" + houseNumber + '\'' + ", cityName='" + cityName
        + '\'' + ", streetNumber='" + streetNumber + '\'' + ", zipCode="
        + zipCode + '}';
  }
}
