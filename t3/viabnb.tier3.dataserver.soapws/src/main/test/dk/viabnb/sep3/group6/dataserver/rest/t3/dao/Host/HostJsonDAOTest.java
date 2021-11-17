package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl.HostJsonDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceJsonDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class HostJsonDAOTest {

    private HostDAO hostDAO;
    private Host host;



    @BeforeEach
    void setUp()
    {
        //TODO assert return and null + some stuff
        hostDAO = new HostJsonDAO();

    }

    @Test
    void createHostSunnyScenario()
    {
        //arrange
       int hostId = 1;
         String firstName = "Bob";
         String lastName = "Bobsen";
         String phoneNumber = "12345678";
         String email = "bob@bobsen.dk";
         String password = "bob12345";
         List<HostReview> hostReviews = null;
         String profileImageUrl =null;
         boolean isApprovedHost = false;
         host = new Host(1, firstName, lastName, phoneNumber,
                email, password, hostReviews, profileImageUrl, isApprovedHost);

        //act and assert
        assertDoesNotThrow(() -> hostDAO.RegisterHost(host));
    }

}