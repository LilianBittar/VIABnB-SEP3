package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.util.List;
//TODO: Implement this later. Use ResidenceJsonDAO as tempoary storage.
@Repository
@Scope("singleton")
public class ResidenceDAOImpl implements ResidenceDAO
{

  @Override public Residence getByResidenceId(int id)
  {
    return null;
  }

  @Override public List<Residence> getAllResidenceByHostId(int id)
  {
    return null;
  }

  @Override public Residence createResidence(Residence residence)
  {
    return null;
  }
}
