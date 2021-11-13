package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.administration;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;
import org.omg.CosNaming.NamingContextPackage.NotFound;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.io.*;
import java.lang.reflect.Type;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

@Repository @Scope("singleton") public class AdministrationJsonDAO
    implements AdministrationDAO
{
  private final String JSON_FILE_NAME = "hostReg.json";
  private List<HostRegistrationRequest> requests;
  private Gson gson = new Gson();

  public AdministrationJsonDAO()
  {
    File file = new File(JSON_FILE_NAME);
    if (!file.exists())
    {
      try
      {
        file.createNewFile();
        requests = new ArrayList<>();
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
        String requestAsJson = "";
        while ((requestAsJson = reader.readLine()) != null)
        {
          Type type = new TypeToken<ArrayList<HostRegistrationRequest>>()
          {
          }.getType();
          List<HostRegistrationRequest> requestList = gson.fromJson(
              requestAsJson, type);
          requests = requestList;
        }
      }
      catch (IOException e)
      {
        e.printStackTrace();
      }
    }
  }

  @Override public List<HostRegistrationRequest> getAllHostRegistrationRequests()
  {
    List<HostRegistrationRequest> requests;
    try
    {
      Reader reader = Files.newBufferedReader(Paths.get(JSON_FILE_NAME));
      requests = new Gson().fromJson(reader,
          new TypeToken<List<HostRegistrationRequest>>()
          {
          }.getType());
      return requests;
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
    return null;
  }

  @Override public List<HostRegistrationRequest> getHostRegistrationRequestsByHostId(
      int hostId)
  {
    //Todo need a host!!
    return null;
  }

  @Override public HostRegistrationRequest getHostRegistrationRequestsById(
      int requestId)
  {
    List<HostRegistrationRequest> requestsList;
    HostRegistrationRequest request;
    try
    {
      Reader reader = Files.newBufferedReader(Paths.get(JSON_FILE_NAME));
      requestsList = new Gson().fromJson(reader,
          new TypeToken<List<HostRegistrationRequest>>()
          {
          }.getType());
      for (HostRegistrationRequest r : requestsList)
      {
        if (r.getId() == requestId)
        {
          request = r;
          return request;
        }
        throw new NotFound();
      }
    }
    catch (IOException | NotFound e)
    {
      e.printStackTrace();
    }
    return null;
  }

  @Override public boolean isValidHost(int requestId, RequestStatus status)
  {
    List<HostRegistrationRequest> requestsList;
    HostRegistrationRequest request;
    try
    {
      Reader reader = Files.newBufferedReader(Paths.get(JSON_FILE_NAME));
      requestsList = new Gson().fromJson(reader,
          new TypeToken<List<HostRegistrationRequest>>()
          {
          }.getType());
      for (HostRegistrationRequest r : requestsList)
      {
        if (r.getId() == requestId)
        {
          request = r;
          request.setStatus(status);
          return true;
        }
        else
        {
          throw new NotFound();
        }
      }
    }
    catch (IOException | NotFound e)
    {
      e.printStackTrace();
    }
    return false;
  }
}
