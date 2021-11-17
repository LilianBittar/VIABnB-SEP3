package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestregistrationrequest;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
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
import java.util.NoSuchElementException;

@Repository
@Scope("singleton")
public class GuestRegistrationRequestJsonDAO implements GuestRegistrationRequestDAO {
    private final static String REQUESTS_FILE = "guestRegReq.json";
    private List<GuestRegistrationRequest> allRequests;
    private Gson gson = new GsonBuilder().serializeNulls().create();

    public GuestRegistrationRequestJsonDAO() {
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
                    Type type = new TypeToken<ArrayList<GuestRegistrationRequest>>()
                    {
                    }.getType();
                    allRequests = gson.fromJson(
                            requestAsJson, type);
                }
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }
        }
    }

    @Override
    public GuestRegistrationRequest createGuestRegistrationRequest(GuestRegistrationRequest request) {
        allRequests.add(request);
        writeAllRequestsToFile();
        return request;
    }

    @Override
    public List<GuestRegistrationRequest> getAllGuestRegistrationRequests() {
        return allRequests;
    }

    @Override public GuestRegistrationRequest getGuestRegistrationRequestByHostId(
        int hostId)
    {
        //TODO update model class to include a host or a host id
        return null;
    }

    @Override public GuestRegistrationRequest getGuestRegistrationRequestById(
        int requestId)
    {
        GuestRegistrationRequest request = null;
        for (GuestRegistrationRequest req : allRequests)
        {
            if (req.getId() == requestId)
            {
                request = req;
            }
        }
        return request;
    }

    @Override
    public GuestRegistrationRequest approveGuestRegistrationRequest(GuestRegistrationRequest request) {
        GuestRegistrationRequest existingRequest = allRequests.get(allRequests.indexOf(request));
        if (existingRequest == null){
            throw new NoSuchElementException();
        }
        existingRequest.setStatus(RequestStatus.Approved);
        //TODO: Change status of the guest to isApproved, when we have an Guest repository
        writeAllRequestsToFile();
        return existingRequest;
    }

    @Override
    public GuestRegistrationRequest rejectGuestRegistrationRequest(GuestRegistrationRequest request) {
        GuestRegistrationRequest existingRequest = allRequests.get(allRequests.indexOf(request));
        if (existingRequest == null){
            throw new NoSuchElementException();
        }
        existingRequest.setStatus(RequestStatus.NotApproved);
        writeAllRequestsToFile();
        return existingRequest;
    }

    private void writeAllRequestsToFile(){
        File file = new File(REQUESTS_FILE);
        try {
            FileWriter fileWriter = new FileWriter(file);
            fileWriter.write(gson.toJson(allRequests));
            fileWriter.close();
        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}
