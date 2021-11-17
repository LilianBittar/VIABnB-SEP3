package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;

import java.io.*;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

public class HostJsonDAO implements HostDAO {

    private final String HOST_FILE = "hosts.json";
    private List<Host> hosts;
    private Gson gson = new Gson();

    public HostJsonDAO() {
        File file = new File(HOST_FILE);
        if (!file.exists()) {
            try {
                file.createNewFile();
                hosts = new ArrayList<>();
            } catch (IOException e) {
                e.printStackTrace();
            }

        } else {

            try {
                FileReader fileReader = new FileReader(file);
                BufferedReader reader = new BufferedReader(fileReader);
                String hostsAsJson = "";
                while ((hostsAsJson = reader.readLine()) != null) {
                    Type l = new TypeToken<ArrayList<Residence>>() {
                    }.getType();
                    List<Host> hList = gson.fromJson(hostsAsJson, l);
                    hosts = hList;
                    for (Host h : hosts) {
                        System.out.println(h.toString());
                    }
                }

            } catch (IOException e) {
                e.printStackTrace();
            }
        }

    }

    @Override
    public Host RegisterHost(Host host) {
        File file = new File(HOST_FILE);
        try {
            System.out.println(host.toString());
            hosts.add(host);
            FileWriter fileWriter = new FileWriter(file);
            fileWriter.write(gson.toJson(hosts));
            fileWriter.close();
            return host;
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }
}

