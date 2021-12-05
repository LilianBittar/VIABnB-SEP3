package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequest;

import java.util.List;

public interface RentRequestDAO {
    /**
     * Creates a new RentRequest and stores the request in DB.
     * @param request RentRequest that is to be created.
     * @return the created RentRequest
     * @exception IllegalStateException Connection to Data source has failed.
     * */
    RentRequest createNewRentRequest(RentRequest request) throws IllegalStateException;
    /**
     * Update a rent request
     * @param request The targeted rent request to update
     * @return The newly updaated rent request
     *
     * @throws IllegalStateException if can't connect to database
     * */
    RentRequest updateRentRequest(RentRequest request);
    /**
     * Handle a query that returns a rent request based on the given parameter
     * @param id The targeted rent request's id
     * @return a rent request object
     *
     * @throws IllegalStateException if can't connect to database
     * */
    RentRequest getRentRequestById(int id);
    /**
     * Handle a query that returns a list of rent request objects
     * @return all the rent requests in the system
     *
     * @throws IllegalStateException if can't connect to database
     * */
    List<RentRequest> getAllRentRequests();
    /**
     * Update the status of a rent request from false to true
     * @param request The targeted rent request to be updated
     * @return The newly updated rent request
     *
     * @throws IllegalStateException if can't connect to database
     * */
    RentRequest approveRentRequest(RentRequest request);
    /**
     * Remove a rent request from the system
     * @param request The targeted rent request for removal
     * @return The newly removed rent request
     *
     * @throws IllegalStateException if can't connect to database
     * */
    RentRequest rejectRentRequest(RentRequest request);
}
