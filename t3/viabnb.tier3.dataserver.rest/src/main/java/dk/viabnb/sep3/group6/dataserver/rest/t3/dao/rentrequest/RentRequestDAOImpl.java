package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequestStatus;

import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;

public class RentRequestDAOImpl extends BaseDao implements RentRequestDAO {

    @Override
    public RentRequest create(RentRequest request) {
        try (Connection connection = getConnection()){
            PreparedStatement stm = connection.prepareStatement("insert into rentrequest(startdate, enddate, numberofguests, status, hostid) values (?,?,?,?,?)");
            stm.setDate(1, Date.valueOf(request.getStartDate().toString()));
            stm.setDate(2, Date.valueOf(request.getEndDate().toString()));
            stm.setInt(3, request.getNumberOfGuests());
            stm.setString(4, RentRequestStatus.NOTANSWERED.name());
            stm.setInt(5, request.getResidence().getHost().getId());
            stm.executeUpdate();
            connection.commit();
            return request;

        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public RentRequest update(RentRequest request) {
        return null;
    }

    @Override
    public RentRequest getById(int id) {
        return null;
    }

    @Override
    public List<RentRequest> getAll() {
        return null;
    }
}
