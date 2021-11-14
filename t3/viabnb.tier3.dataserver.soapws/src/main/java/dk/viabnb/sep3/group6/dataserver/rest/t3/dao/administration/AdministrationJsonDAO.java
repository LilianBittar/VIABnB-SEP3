package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.administration;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestRegistrationRequest;
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
  private final String JSON_FILE_NAME_G = "guestRegReq.json";
  private List<HostRegistrationRequest> hostRequests;
  private List<GuestRegistrationRequest> guestRequests;
  private Gson gson = new Gson();

  public AdministrationJsonDAO()
  {
    File file1 = new File(JSON_FILE_NAME);
    File file2 = new File(JSON_FILE_NAME_G);
    if (!file1.exists())
    {
      try
      {
        file1.createNewFile();
        hostRequests = new ArrayList<>();
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
        FileReader fileReader = new FileReader(file1);
        BufferedReader reader = new BufferedReader(fileReader);
        String requestAsJson = "";
        while ((requestAsJson = reader.readLine()) != null)
        {
          Type type = new TypeToken<ArrayList<HostRegistrationRequest>>()
          {
          }.getType();
          List<HostRegistrationRequest> requestList = gson.fromJson(
              requestAsJson, type);
          hostRequests = requestList;
        }
      }
      catch (IOException e)
      {
        e.printStackTrace();
      }
    }
    if (!file2.exists())
    {
      try
      {
        file2.createNewFile();
        guestRequests = new ArrayList<>();
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
        FileReader fileReader = new FileReader(file2);
        BufferedReader reader = new BufferedReader(fileReader);
        String requestAsJson = "";
        while ((requestAsJson = reader.readLine()) != null)
        {
          Type type = new TypeToken<ArrayList<GuestRegistrationRequest>>()
          {
          }.getType();
          List<GuestRegistrationRequest> requestList = gson.fromJson(
              requestAsJson, type);
          guestRequests = requestList;
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
    /*List<HostRegistrationRequest> requestsList;
    List<HostRegistrationRequest> requestsListToReturn = new ArrayList<>();
    HostRegistrationRequest request;
    try
    {
      Reader reader = Files.newBufferedReader(Paths.get(JSON_FILE_NAME_G));
      requestsList = new Gson().fromJson(reader,
          new TypeToken<List<HostRegistrationRequest>>()
          {
          }.getType());
      for (HostRegistrationRequest r : requestsList)
      {
        if (r.getHost.getId == hostId)
        {
          request = r;
          requestsListToReturn.add(request);
          return requestsListToReturn;
        }
      }
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }*/
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

  @Override public List<GuestRegistrationRequest> getAllGuestRegistrationRequest()
  {
    List<GuestRegistrationRequest> requests;
    try
    {
      Reader reader = Files.newBufferedReader(Paths.get(JSON_FILE_NAME_G));
      requests = new Gson().fromJson(reader,
          new TypeToken<List<GuestRegistrationRequest>>()
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

  @Override public List<GuestRegistrationRequest> getGuestRegistrationRequestByGuestId(
      int hostId)
  {
    //Todo need a Guest
    /*List<GuestRegistrationRequest> requestsList;
    List<GuestRegistrationRequest> requestsListToReturn = new ArrayList<>();
    GuestRegistrationRequest request;
    try
    {
      Reader reader = Files.newBufferedReader(Paths.get(JSON_FILE_NAME_G));
      requestsList = new Gson().fromJson(reader,
          new TypeToken<List<GuestRegistrationRequest>>()
          {
          }.getType());
      for (GuestRegistrationRequest r : requestsList)
      {
        if (r.getHost.getId == hostId)
        {
          request = r;
          requestsListToReturn.add(request);
          return requestsListToReturn;
        }
      }
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }*/
    return null;
  }

  @Override public GuestRegistrationRequest getGuestRegistrationRequestById(
      int requestId)
  {
    List<GuestRegistrationRequest> requestsList;
    GuestRegistrationRequest request;
    try
    {
      Reader reader = Files.newBufferedReader(Paths.get(JSON_FILE_NAME_G));
      requestsList = new Gson().fromJson(reader,
          new TypeToken<List<GuestRegistrationRequest>>()
          {
          }.getType());
      for (GuestRegistrationRequest r : requestsList)
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

  @Override public boolean isValidGuest(int requestId, RequestStatus status)
  {
    List<GuestRegistrationRequest> requestsList;
    GuestRegistrationRequest request;
    try
    {
      Reader reader = Files.newBufferedReader(Paths.get(JSON_FILE_NAME_G));
      requestsList = new Gson().fromJson(reader,
          new TypeToken<List<GuestRegistrationRequest>>()
          {
          }.getType());
      for (GuestRegistrationRequest r : requestsList)
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
