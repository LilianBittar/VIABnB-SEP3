package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;
//TODO: We need ResidenceRating model class and DAO to implement this

public class ResidenceDAOImpl extends BaseDao implements ResidenceDAO
{
  private AddressDAO addressDAO = new AddressDAOImpl();

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
