package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

public class HostController {

    private HostDAO hostDAO;
    private Gson gson = new GsonBuilder().serializeNulls().create();

    @Autowired
    public HostController(@Qualifier("HostJsonDAO") HostDAO hostDAO)
    {
        this.hostDAO = hostDAO;
    }




    @PostMapping("/host")
    public ResponseEntity<Host> createHost(@RequestBody Host host  )
    {
        Host newHost = hostDAO.RegisterHost(host);
        if (newHost == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(newHost, HttpStatus.OK);
    }
}
