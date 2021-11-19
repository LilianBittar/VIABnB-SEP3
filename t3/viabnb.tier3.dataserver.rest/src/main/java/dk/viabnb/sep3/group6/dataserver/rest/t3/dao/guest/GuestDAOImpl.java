package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

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
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("select * from host h join guest g on h.hostid = g.guestid");
            ResultSet result = stm.executeQuery();
            List<Guest> allGuests = new ArrayList<>();
            while (result.next()){
            Guest existingGuest =  new Guest(result.getInt("hostid"),
                    result.getString("fname"), result.getString("lname"),
                    result.getString("phonenumber"), result.getString("email"),
                    result.getString("password"), new ArrayList<>(),
                    result.getString("personalimage"),
                    result.getString("cprnumber"),
                    result.getBoolean("isapproved"), result.getInt("viaid"),
                    result.getBoolean("isapprovedguest"));
                allGuests.add(existingGuest);
            }
            return allGuests;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
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
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("select * from host h join guest g on h.hostid = g.guestid where h.hostid = ?");
            stm.setInt(1, id);
            ResultSet result = stm.executeQuery();
            result.next();
            return new Guest(result.getInt("hostid"),
                    result.getString("fname"), result.getString("lname"),
                    result.getString("phonenumber"), result.getString("email"),
                    result.getString("password"), new ArrayList<>(),
                    result.getString("personalimage"),
                    result.getString("cprnumber"),
                    result.getBoolean("isapproved"), result.getInt("viaid"),
                    result.getBoolean("isapprovedguest"));
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

}
