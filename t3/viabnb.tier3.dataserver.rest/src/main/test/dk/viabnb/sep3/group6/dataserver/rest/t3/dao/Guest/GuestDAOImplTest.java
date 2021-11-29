package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl.HostDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAOImpl;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;

public class GuestDAOImplTest {


    private GuestDAO guestDAO;
    private int studentNumber;


    @BeforeEach
    void setUp()
    {
        guestDAO = new GuestDAOImpl();
        studentNumber = 111111;
    }

    @Test
    void getGuestByStudentNumberSunnyScenario()
    {
        assertDoesNotThrow(() -> guestDAO.getGuestByStudentNumber(studentNumber));
    }

    @Test
    void getGuestByStudentNumberRainyScenario()
    {
        assertDoesNotThrow(() -> guestDAO.getGuestByStudentNumber(123456));
    }
}
