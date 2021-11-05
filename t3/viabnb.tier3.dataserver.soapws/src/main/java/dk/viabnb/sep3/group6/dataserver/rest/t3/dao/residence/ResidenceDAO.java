package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

public interface ResidenceDAO
{
  Residence getByResidenceId(int id);
  List<Residence> getAllResidenceByHostId(int id);
}
