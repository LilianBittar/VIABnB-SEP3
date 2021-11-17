package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class GuestDAOImpl extends BaseDao implements GuestDAO {
    @Override
    public Guest createGuestRegistrationRequest(Guest request) {
        return null;
    }

    @Override
    public List<Guest> getAllGuestRegistrationRequests() {
        return null;
    }

    @Override
    public Guest approveGuestRegistrationRequest(Guest request) {
        return null;
    }

    @Override
    public Guest rejectGuestRegistrationRequest(Guest request) {
        return null;
    }

    @Override
    public Guest getGuestRegistrationRequestByHostId(int hostId) {
        return null;
    }

    @Override
    public Guest getGuestRegistrationRequestById(int requestId) {
        return null;
    }
}
