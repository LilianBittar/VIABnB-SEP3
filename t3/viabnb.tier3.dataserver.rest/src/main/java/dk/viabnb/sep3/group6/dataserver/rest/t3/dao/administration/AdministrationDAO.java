package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Administrator;

import java.util.List;

public interface AdministrationDAO
{
  Administrator getAdministratorByEmail(String email);
  List<Administrator> getAllAdministrators();
}
