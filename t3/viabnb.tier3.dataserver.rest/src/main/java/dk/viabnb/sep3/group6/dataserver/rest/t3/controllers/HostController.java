package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.RunDataServer;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController
public class HostController
{
    private static final Logger LOGGER= LoggerFactory.getLogger(HostController.class);

    // TODO: rename the paths to use /hosts/... as that is the standard for RESTful collections.
    private HostDAO hostDAO;
    private Gson gson = new GsonBuilder().serializeNulls().create();

    @Autowired
    public HostController(/*@Qualifier("HostDAOImpl") */HostDAO hostDAO)
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
//TODO: This is conflicting with the handler for /host/{id}. Move this into a getAllHosts method and make email and query param instead. -micmic2
//    @GetMapping("/host/{email}")
//    public ResponseEntity<Host> getHostByEmail(@PathVariable String email)
//    {
//        Host host;
//        host = hostDAO.getHostByEmail(email);
//        if (host == null){
//            return ResponseEntity.internalServerError().build();
//        }
//        return new ResponseEntity<>(host, HttpStatus.OK);
//    }
    @GetMapping("/host/{id}")
    public ResponseEntity<Host> getHostById(@PathVariable int id)
    {
        Host host;
        host = hostDAO.getHostById(id);
        //Host can be null, because of the host can just not exist in the system. Does not need to be a server error that caused it. -micmic
        //Better to just return the null, and let t2 handle the business logic. -micmic
//        if (host == null){
//            return ResponseEntity.internalServerError().build();
//        }
        LOGGER.info("Request for: " + gson.toJson(host));
        return new ResponseEntity<>(host, HttpStatus.OK);
    }

    @GetMapping("/hosts/notApproved")
    public ResponseEntity<List<Host>> getAllNotApprovedHosts()
    {
        List<Host> hostsToReturn;
        hostsToReturn = hostDAO.getAllNotApprovedHosts();
        if (hostsToReturn == null)
        {
            return ResponseEntity.internalServerError().build();
        }
        return new ResponseEntity<>(hostsToReturn, HttpStatus.OK);
    }

    @PatchMapping("/host/{id}/approval")
    public ResponseEntity<Host> updateHostStatus(@RequestBody Host host, @RequestParam("id") int id )
    {
        try
        {
            if (host.isApprovedHost())
            {
                Host approvedHost = hostDAO.approveHost(host);
                return ResponseEntity.ok(approvedHost);
            }
            else if (!host.isApprovedHost())
            {
                Host rejectedHost = hostDAO.rejectHost(host);
                return ResponseEntity.ok(rejectedHost);
            }
            return ResponseEntity.badRequest().build();
        }
        catch (NoSuchElementException e)
        {
            return ResponseEntity.notFound().build();
        }
    }
}
