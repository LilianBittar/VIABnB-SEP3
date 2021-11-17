package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.authentication.HostAuthenticationDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;


@RestController  public class AuthenticationController {
    private HostAuthenticationDAO hostAuthenticationDAO;
    private Gson gson = new GsonBuilder().serializeNulls().create();

    @Autowired public AuthenticationController(@Qualifier("hostAuthenticationJsonDAO") HostAuthenticationDAO hostAuthenticationDAO)
    {
        this.hostAuthenticationDAO = hostAuthenticationDAO;
    }

    @GetMapping("/host/{email}")
    public ResponseEntity<Host> getHostByEmail(@PathVariable String email)
    {
        Host host;
        host = hostAuthenticationDAO.GetHostByEmail(email);
        if (host == null){
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(host, HttpStatus.OK);
    }
    @GetMapping("/host/{id}")
    public ResponseEntity<Host> getHostById(@PathVariable int id)
    {
        Host host;
        host = hostAuthenticationDAO.GetHostById(id);
        if (host == null){
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(host, HttpStatus.OK);
    }

}
