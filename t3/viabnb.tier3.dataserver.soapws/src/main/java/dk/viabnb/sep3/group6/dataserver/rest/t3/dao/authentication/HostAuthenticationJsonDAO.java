package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.authentication;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostAuthenticationRequest;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.lang.reflect.Type;
import java.util.ArrayList;

import java.util.List;
import java.util.NoSuchElementException;

@Repository @Scope("singleton")
public class HostAuthenticationJsonDAO implements HostAuthenticationDAO{

    private final static String REQUESTS_FILE = "host.json";
    private List<Host> hosts;
    private Gson gson = new GsonBuilder().serializeNulls().create();

    public HostAuthenticationJsonDAO(){
        File file  = new File(REQUESTS_FILE);
        if (!file.exists())
        {
            try
            {
                file.createNewFile();
                hosts = new ArrayList<>();
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
                    Type type = new TypeToken<ArrayList<Host>>()
                    {
                    }.getType();
                    hosts = gson.fromJson(
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
    public Host GetHostByEmail(String email){
        for (int i = 0; i < hosts.size(); i++){
            if(hosts.get(i).getEmail().equals(email)){
                return hosts.get(i);
            }
        }
        return null;
    }

    @Override
    public Host GetHostById(int Id){
        for (int i = 0; i < hosts.size(); i++){
            if(hosts.get(i).getId()==Id){
                return hosts.get(i);
            }
        }
        return null;
    }


}
