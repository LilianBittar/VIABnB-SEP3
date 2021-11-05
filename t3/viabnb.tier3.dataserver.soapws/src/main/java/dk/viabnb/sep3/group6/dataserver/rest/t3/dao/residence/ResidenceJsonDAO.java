package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.google.gson.Gson;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.lang.reflect.Type;

import com.google.gson.reflect.TypeToken;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@Repository @Scope("singleton") public class ResidenceJsonDAO
    implements ResidenceDAO
{
  private final String RESIDENCE_FILE = "residences.json";
  private List<Residence> residences;
  private Gson gson = new Gson();

  public ResidenceJsonDAO()
  {
    File file = new File(RESIDENCE_FILE);
    if (!file.exists())
    {
      try
      {
        file.createNewFile();
        residences = new ArrayList<>();
      }
      catch (IOException e)
      {
        e.printStackTrace();
      }

    }
    else
    {

      try
      {
        FileReader fileReader = new FileReader(file);
        BufferedReader reader = new BufferedReader(fileReader);
        String residencesAsJson = "";
        while ((residencesAsJson = reader.readLine()) != null)
        {
          Type l = new TypeToken<ArrayList<Residence>>()
          {
          }.getType();
          List<Residence> rList = gson.fromJson(residencesAsJson, l);
          residences = rList;
          for (Residence r : residences)
          {
            System.out.println(r.toString());
          }
        }

      }
      catch (IOException e)
      {
        e.printStackTrace();
      }
    }

  }

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
      System.out.println(residence.toString());
      residences.add(residence);
      FileWriter fileWriter = new FileWriter(file);
      fileWriter.write(gson.toJson(residences));
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
