package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.hostregistrationrequest;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostRegistrationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RequestStatus;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.io.*;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

@Repository
@Scope("singleton")
public class HostRegistrationRequestJsonDAO implements HostRegistrationRequestDAO
{
  private final static String REQUESTS_FILE = "hostRegistrationRequest.json";
  private List<HostRegistrationRequest> allRequests;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  public HostRegistrationRequestJsonDAO()
  {
    File file = new File(REQUESTS_FILE);
    if (!file.exists())
    {
      try
      {
        file.createNewFile();
        allRequests = new ArrayList<>();
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
          allRequests = gson.fromJson(requestAsJson, type);
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
    return allRequests;
  }

  @Override public HostRegistrationRequest getHostRegistrationRequestsByHostId(
      int hostId)
  {
    HostRegistrationRequest request = null;
    for (HostRegistrationRequest req : allRequests)
    {
      if (req.getHost().getId() == hostId)
      {
        request = req;
      }
    }
    return request;
  }

  @Override public HostRegistrationRequest getHostRegistrationRequestsById(
      int requestId)
  {
    HostRegistrationRequest request = null;
    for (HostRegistrationRequest req : allRequests)
    {
      if (req.getHost().getId() == requestId)
      {
        request = req;
      }
    }
    return request;
  }

  @Override public HostRegistrationRequest approveHostRegistrationRequest(
      HostRegistrationRequest request)
  {
    HostRegistrationRequest req = allRequests.get(allRequests.indexOf(request));
    if (req == null)
    {
      throw new NoSuchElementException();
    }
    req.setStatus(RequestStatus.Approved);
    writeToJson();
    return req;
  }

  @Override public HostRegistrationRequest rejectHostRegistrationRequest(
      HostRegistrationRequest request)
  {
    HostRegistrationRequest req = allRequests.get(allRequests.indexOf(request));
    if (req == null)
    {
      throw new NoSuchElementException();
    }
    req.setStatus(RequestStatus.NotApproved);
    writeToJson();
    return req;
  }

  private void writeToJson()
  {
    File file = new File(REQUESTS_FILE);
    try
    {
      FileWriter fileWriter = new FileWriter(file);
      fileWriter.write(gson.toJson(allRequests));
      fileWriter.close();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
  }
}
