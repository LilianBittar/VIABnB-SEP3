package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;

import java.util.List;

public interface HostDAO
{
    Host RegisterHost(Host host);
    Host getHostByEmail(String email);
    Host getHostById(int Id);
    List<Host> getAllHosts();
    /**
     * Query a list of Host objects that have a false isApprovedHost boolean value
     * @return List<Host>
     * @throws IllegalStateException on SQL failure
     * */
    List<Host> getAllNotApprovedHosts();
    /**
     * Update the boolean isApprovedHost value of a given host from false to true
     * @param host The targeted host
     * @return Updated Host object with isApprovedHost boolean value true
     * @throws IllegalStateException on SQL failure or invalid host
     * */
    Host approveHost(Host host);
    /**
     * Delete a Host object that have a boolean isApprovedHost value false
     * @param host The targeted host
     * @return Updated host object with isApprovedHost boolean value of false
     * @throws IllegalStateException on SQL failure or invalid host
     * */
    Host rejectHost(Host host);
}
