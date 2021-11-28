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
    RentRequest create(RentRequest request) throws IllegalStateException;
    RentRequest update(RentRequest request);
    RentRequest getById(int id);
    List<RentRequest> getAll();
    RentRequest approveRequest(RentRequest request);
    RentRequest rejectRequest(RentRequest request);
}
