package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl.HostDAOImpl;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class HostAuthenticationDAOTest {

    private HostDAO hostDAO;
    private String email;
    private int id;



    @BeforeEach
    void setUp()
    {
        hostDAO = new HostDAOImpl();
        email = "catman@catnet.com";
        id = 1;

    }

    @Test
    void getHostByIdSunnyScenario()
    {
        assertDoesNotThrow(() -> hostDAO.getHostById(id));
    }


    @Test
    void getHostByEmailSunnyScenario()
    {
        assertDoesNotThrow(() -> hostDAO.getHostByEmail(email));
    }
}