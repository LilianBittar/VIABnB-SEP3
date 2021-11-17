package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Facility;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;
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

  @BeforeEach void setUp()
  {
    residenceDAO = new ResidenceJsonDAO();

    address = new Address(1, "streetNameTest", "h1", "cityTest", "s1", 1111);

    facilities = new ArrayList<>();
    facilities.add(new Facility(1, "nameTest"));

    rules = new ArrayList<>();
    rules.add(new Rule(1, "descriptionTest"));

    residence = new Residence(1, address, "descriptionTest", "typeTest",
        1.5, false, 1.5, rules, facilities, "urlTest", new Date("11/11/2021"), new Date("11/11/2021"));
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