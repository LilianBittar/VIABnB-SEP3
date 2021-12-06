package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import com.fasterxml.jackson.annotation.JsonProperty;

public class City
{
  @JsonProperty("id")
  private int cityId;
  private String cityName;
  private int zipCode;

  public City(int cityId, String cityName, int zipCode)
  {
    this.cityId = cityId;
    this.cityName = cityName;
    this.zipCode = zipCode;
  }

  public int getCityId()
  {
    return cityId;
  }

  public void setCityId(int cityId)
  {
    this.cityId = cityId;
  }

  public String getCityName()
  {
    return cityName;
  }

  public void setCityName(String cityName)
  {
    this.cityName = cityName;
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
    return "City{" + "cityId=" + cityId + ", cityName='" + cityName + '\''
        + ", zipCode=" + zipCode + '}';
  }
}
