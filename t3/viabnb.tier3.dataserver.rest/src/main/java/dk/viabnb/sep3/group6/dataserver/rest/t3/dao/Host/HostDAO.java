package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;

import java.util.List;

public interface HostDAO
{
    /**
     * Create a new host object
     * @param host The new host object
     * @return The newly created host object
     *
     * @throws IllegalStateException if can't connect to database
     * */
    Host registerHost(Host host);
    /**
     * Handle a query that returns a host object based on the given parameter
     * @param email The targeted host's enail
     * @return a host object if any, or null
     *
     * @throws IllegalStateException if can't connect to database
     * */
    Host getHostByEmail(String email);
    /**
     * Handle a query that returns a host object based on the given parameter
     * @param id The targeted host's id
     * @return a host object if any, or null
     *
     * @throws IllegalStateException if can't connect to database
     * */
    Host getHostById(int id);
    /**
     * Handle a query that returns all the host objects in the system
     * @return a list of host objects if any, or null
     *
     * @throws IllegalStateException if can't connect to database
     * */
    List<Host> getAllHosts();
    /**
     * Query a list of Host objects that have a false isApprovedHost boolean value
     * @return List<Host>
     * @throws IllegalStateException if can't connect to database
     * */
    List<Host> getAllNotApprovedHosts();
    /**
     * Update the boolean isApprovedHost value of a given host from false to true
     * @param host The targeted host
     * @return Updated Host object with isApprovedHost boolean value true
     * @throws IllegalStateException if can't connect to database
     * */
    Host approveHost(Host host);
    /**
     * Delete a Host object that have a boolean isApprovedHost value false
     * @param host The targeted host
     * @return Updated host object with isApprovedHost boolean value of false
     * @throws IllegalStateException if can't connect to database
     * */
    Host rejectHost(Host host);
}
