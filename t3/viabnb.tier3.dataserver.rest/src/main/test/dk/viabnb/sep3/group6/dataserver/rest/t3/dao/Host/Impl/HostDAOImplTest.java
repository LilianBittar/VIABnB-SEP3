package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class HostDAOImplTest
{
  private HostDAO hostDAO;

  @BeforeEach
  public void setUp()
  {
    hostDAO = new HostDAOImpl();
  }

  @Test
  public void get()
  {
    assertDoesNotThrow(()-> hostDAO.getAllNotApprovedHosts());
  }

  @Test void get2()
  {
    List<Host> hosts = new ArrayList<>();
    hosts = hostDAO.getAllHosts();
    assertEquals(1, hosts.get(1).getId());
  }

  @Test void get3()
  {
    assertNotNull(hostDAO.getAllNotApprovedHosts());
  }

  @Test void getHostByIdSunnySenario(){
    assertDoesNotThrow(() -> hostDAO.getHostById(1));
  }

  @Test void getHostByIdRainySenario(){
    assertThrows(IllegalStateException.class, () -> hostDAO.getHostById(-1));
  }

  @Test void getHostByEmailSunnySenario(){
    assertDoesNotThrow(() -> hostDAO.getHostByEmail("Test@Test.tt"));
  }

  @Test void getHostByEmailRainySenario(){
    assertThrows(IllegalStateException.class,() -> hostDAO.getHostByEmail("nottest@ho"));
  }
}