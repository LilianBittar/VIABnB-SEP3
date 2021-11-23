package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class ResidenceJsonDAOTest
{
  private ResidenceDAO residenceDAO;

  private Address address;
  private List<Facility> facilities;
  private List<Rule> rules;
  private Residence residence;
  private City city;

  @BeforeEach void setUp()
  {
    residenceDAO = new ResidenceDAOImpl();

    city = new City(1, "cityNameTest", 1111);
    address = new Address(1, "streetNameTest", "h1", "cityTest", city);

    facilities = new ArrayList<>();
    facilities.add(new Facility(1, "nameTest"));

    rules = new ArrayList<>();
    rules.add(new Rule(1, "descriptionTest"));


    residence = new Residence(1, address, "des", "ty", 1, false, 1, rules, facilities, "s", new Date("11/11/2021"), new Date("11/11/2021"), 10);
  }

  @Test void createResidenceSunnyScenario()
  {
    assertDoesNotThrow(() -> residenceDAO.createResidence(residence));
  }
  @Test void createNullResidenceTest()
  {
    assertThrows(NullPointerException.class, ()-> residenceDAO.createResidence(null));
  }

  @Test void getAllResidenceByHostIdSunnyDoesNotThrowWithOneResident()
  {
    //arrange
    residenceDAO.createResidence(residence);

    //act and assert
    assertDoesNotThrow(()->residenceDAO.getAllResidenceByHostId(1));
  }



}