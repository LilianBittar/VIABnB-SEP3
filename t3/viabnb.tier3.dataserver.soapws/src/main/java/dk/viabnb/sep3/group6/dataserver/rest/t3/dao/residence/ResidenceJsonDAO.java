package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import com.google.gson.Gson;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.io.*;
import java.util.List;

@Repository
@Scope("singleton")
public class ResidenceJsonDAO implements ResidenceDAO
{
  private final String RESIDENCE_FILE = "residences.json";
  private Gson gson = new Gson();

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
    File file = new File(RESIDENCE_FILE);
    try
    {
      FileWriter fileWriter = new FileWriter(file);
      fileWriter.write(gson.toJson(residence));
      fileWriter.close();
      return residence;
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
  return null;
  }
}
