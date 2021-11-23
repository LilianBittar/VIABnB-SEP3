package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequest;

import java.util.List;

public interface RentRequestDAO {
    RentRequest create(RentRequest request);
    RentRequest update(RentRequest request);
    RentRequest getById(int id);
    List<RentRequest> getAll();
}
