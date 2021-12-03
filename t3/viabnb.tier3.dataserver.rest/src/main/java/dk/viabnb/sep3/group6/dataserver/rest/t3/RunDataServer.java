package dk.viabnb.sep3.group6.dataserver.rest.t3;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl.HostDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.CityDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.CityDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration.AdministrationDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration.AdministrationDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility.FacilityDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility.FacilityDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview.GuestReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview.GuestReviewDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule.RuleDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rule.RuleDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.user.UserDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.user.UserDAOImpl;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Scope;

@SpringBootApplication public class RunDataServer
{
  private static final Logger LOGGER = LoggerFactory.getLogger(
      RunDataServer.class);

  public static void main(String[] args)
  {
    SpringApplication.run(RunDataServer.class, args);
    LOGGER.info("Swagger-UI at: http://localhost:8080/swagger-ui.html");
  }

  @Bean @Scope("singleton") GuestDAO guestDAO()
  {
    return new GuestDAOImpl();
  }

  @Bean @Scope("singleton") HostDAO hostDAO()
  {
    return new HostDAOImpl();
  }

  @Bean @Scope("singleton") ResidenceDAO residenceDAO()
  {
    return new ResidenceDAOImpl();
  }

  @Bean @Scope("singleton") RentRequestDAO rentRequestDAO()
  {
    return new RentRequestDAOImpl();
  }

  @Bean @Scope("singleton") AddressDAO addressDAO()
  {
    return new AddressDAOImpl();
  }

  @Bean @Scope("singleton") CityDAO cityDAO()
  {
    return new CityDAOImpl();
  }

  @Bean @Scope("singleton") AdministrationDAO administrationDAO()
  {
    return new AdministrationDAOImpl();
  }

  @Bean @Scope("singleton") FacilityDAO facilityDAO()

  {
    return new FacilityDAOImpl();
  }

  @Bean @Scope("singleton") RuleDAO ruleDAO()

  {
    return new RuleDAOImpl();
  }

  @Bean @Scope("singleton") UserDAO userDAO()
  {
    return new UserDAOImpl();
  }

  @Bean @Scope("singleton") GuestReviewDAO guestReviewDAO()
  {
    return new GuestReviewDAOImpl();
  }
}

