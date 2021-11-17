package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;

import java.util.List;

public interface ResidenceDAO
{
  Residence getByResidenceId(int id);
  List<Residence> getAllResidenceByHostId(int id);
  Residence createResidence(Residence residence);
}
