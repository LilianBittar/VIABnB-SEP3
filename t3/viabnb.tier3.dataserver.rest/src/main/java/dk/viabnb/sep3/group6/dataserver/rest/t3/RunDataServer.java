package dk.viabnb.sep3.group6.dataserver.rest.t3;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl.HostDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAOImpl;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Scope;

@SpringBootApplication
public class RunDataServer {
    private static final Logger LOGGER = LoggerFactory.getLogger(RunDataServer.class);

    public static void main(String[] args) {
        SpringApplication.run(RunDataServer.class, args);
        LOGGER.info("Swagger-UI at: http://localhost:8080/swagger-ui.html");
    }

    @Bean
    @Scope("singleton")
    GuestDAO guestDAO() {
        return new GuestDAOImpl();
    }

    @Bean
    @Scope("singleton")
    HostDAO hostDAO() {
        return new HostDAOImpl();
    }

    @Bean
    @Scope("singleton")
    ResidenceDAO residenceDAO() {
        return new ResidenceDAOImpl();
    }

    @Bean
    @Scope("singleton")
    RentRequestDAO rentRequestDAO() {
        return new RentRequestDAOImpl();
    }


}
