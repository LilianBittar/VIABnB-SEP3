package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;

@Repository
public class GuestDAOImpl extends BaseDao implements GuestDAO {
    @Override
    public Guest createGuest(Guest guest) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("insert into guest(guestid, viaid, isapprovedguest) VALUES (?, ? ,false)");
            stm.setInt(1, guest.getId());
            stm.setInt(2, guest.getViaId());
            stm.execute();
            return getGuestByHostId(guest.getId());

        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public List<Guest> getAllGuests() {
        return null;
    }

    @Override
    public Guest approveGuest(Guest guest) {
        return null;
    }

    @Override
    public Guest rejectGuest(Guest guest) {
        return null;
    }

    @Override
    public Guest getGuestByHostId(int id) {
        return null;
    }

}
