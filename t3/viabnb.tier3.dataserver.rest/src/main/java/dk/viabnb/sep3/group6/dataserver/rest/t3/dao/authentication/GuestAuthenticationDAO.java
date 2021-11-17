package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.authentication;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestAuthenticationRequest;

public interface GuestAuthenticationDAO {

GuestAuthenticationRequest AuthentificateGuest(GuestAuthenticationRequest request);
}
