package dk.viabnb.sep3.group6.dataserver.rest.t3;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceJsonDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

@SpringBootApplication public class RunDataServer
{


  public static void main(String[] args)
  {
    ResidenceDAO residenceDAO = new ResidenceJsonDAO();
    Residence residence = new Residence(1,
        new Address(1, "1", "da", "csa", "dsadsa", 1), "bob", "dsadsa", 21321,
        false, 321321321, null, null, "dsadsa", null, null);
    ApplicationContext context = new AnnotationConfigApplicationContext();
    residenceDAO.createResidence(residence);

  }
}
