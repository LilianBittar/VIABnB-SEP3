package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.authentication;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestAuthenticationRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostAuthenticationRequest;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

public class HostAuthenticationJsonDAO implements HostAuthenticationDAO{
    private final static String REQUESTS_FILE = "guestRegReq.json";
    private List<HostAuthenticationRequest> allRequests;
    private Gson gson = new GsonBuilder().serializeNulls().create();

    public HostAuthenticationJsonDAO(){
        File file  = new File(REQUESTS_FILE);
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
                    Type type = new TypeToken<ArrayList<HostAuthenticationRequest>>()
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
    public HostAuthenticationRequest AuthenticateHost(HostAuthenticationRequest request) {
        HostAuthenticationRequest existingRequest = allRequests.get(allRequests.indexOf(request));
        if (existingRequest == null){
            throw new NoSuchElementException();
        }
        return existingRequest;
    }
}
