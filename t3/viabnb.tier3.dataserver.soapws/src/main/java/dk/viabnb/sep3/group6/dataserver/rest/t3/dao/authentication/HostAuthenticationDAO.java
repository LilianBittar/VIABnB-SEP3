package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.authentication;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostAuthenticationRequest;

public interface HostAuthenticationDAO {
    HostAuthenticationRequest AuthenticateHost(HostAuthenticationRequest request);
}
