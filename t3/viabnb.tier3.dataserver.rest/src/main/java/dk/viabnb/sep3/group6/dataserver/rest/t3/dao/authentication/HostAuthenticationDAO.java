package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.authentication;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;


public interface HostAuthenticationDAO {
    Host GetHostByEmail(String email);
    Host GetHostById(int Id);
}
