package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest;

import dk.viabnb.sep3.group6.dataserver.rest.t3.controllers.GuestController;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class GuestDAOImpl extends BaseDao implements GuestDAO {
    private static final Logger LOGGER= LoggerFactory.getLogger(GuestDAO.class);

    @Override
    public Guest createGuest(Guest guest) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("insert into guest(guestid, viaid, isapprovedguest) VALUES (?, ? ,false)");
            stm.setInt(1, guest.getId());
            stm.setInt(2, guest.getViaId());
            stm.executeUpdate();
            connection.commit();
            LOGGER.info("executed update: createGuest");
            return getGuestByHostId(guest.getId());

        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    /**
     * Handles querying the database for a list of all guests.
     * @return a list of guests.
     * @throws IllegalStateException if it could not connect to the database
     * */
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


    /**
     * Handles querying the database for a guest with the provided id.
     * @param guest id Required field for filtering guests by id value.
     * @return a guest object or null if it could not find the guest with the provided id.
     * @throws IllegalStateException if it could not connect to the database
     * */
    @Override
    public Guest getGuestByHostId(int id) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("select * from host h join guest g on h.hostid = g.guestid where h.hostid = ?");
            stm.setInt(1, id);
            ResultSet result = stm.executeQuery();
            if (result.next()){
            return new Guest(result.getInt("hostid"),
                    result.getString("fname"), result.getString("lname"),
                    result.getString("phonenumber"), result.getString("email"),
                    result.getString("password"), new ArrayList<>(),
                    result.getString("personalimage"),
                    result.getString("cprnumber"),
                    result.getBoolean("isapproved"), result.getInt("viaid"),
                    result.getBoolean("isapprovedguest"));
            }
            return null;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    /**
     * Handles querying the database for a list of all not approved guest.
     * @return a list of  guest that were not approved.
     * @throws IllegalStateException if it could not connect to the database
     * */

    @Override public List<Guest> getAllNotApprovedGuests()
    {
        List<Guest> guestsToReturn = new ArrayList<>();
        try(Connection connection = getConnection())
        {
            PreparedStatement stm = connection.prepareStatement(
                ("SELECT * FROM host h JOIN guest g on h.hostid = g.guestid WHERE isapprovedguest = ?")
            );
                stm.setBoolean(1, false);
                ResultSet result = stm.executeQuery();
                while (result.next())
                {
                    Guest guestToAdd = new Guest
                        (
                            result.getInt("hostid"),
                            result.getString("fname"),
                            result.getString("lname"),
                            result.getString("phonenumber"),
                            result.getString("email"),
                            result.getString("password"),
                            new ArrayList<>(),
                            result.getString("personalimage"),
                            result.getString("cprnumber"),
                            result.getBoolean("isapproved"),
                            result.getInt("viaid"),
                            result.getBoolean("isapprovedguest")
                        );
                    guestsToReturn.add(guestToAdd);
                }
            return guestsToReturn;
        }
        catch (SQLException throwables)
        {
            throw new IllegalStateException(throwables.getMessage());
        }
    }


    @Override
    public Guest getGuestByStudentNumber(int studentNumber) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("select * from host h join guest g on h.hostid = g.guestid where viaid = ?");
            stm.setInt(1, studentNumber);
            ResultSet result = stm.executeQuery();
            if (result.next()){
                return new Guest(result.getInt("hostid"),
                        result.getString("fname"), result.getString("lname"),
                        result.getString("phonenumber"), result.getString("email"),
                        result.getString("password"), new ArrayList<>(),
                        result.getString("personalimage"),
                        result.getString("cprnumber"),
                        result.getBoolean("isapproved"), result.getInt("viaid"),
                        result.getBoolean("isapprovedguest"));
            }
            return null;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public Guest approveGuest(Guest guest)
    {
        try(Connection connection = getConnection())
        {
            PreparedStatement stm = connection.prepareStatement
                ("UPDATE guest SET isapprovedguest = true WHERE guestid = ?");
            stm.setInt(1, guest.getId());
            stm.executeUpdate();
            connection.commit();
            return guest;
        }
        catch (SQLException throwables)
        {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public Guest rejectGuest(Guest guest)
    {
        try(Connection connection = getConnection())
        {
            PreparedStatement stm = connection.prepareStatement
                ("DELETE FROM guest WHERE guestid = ?");
            stm.setInt(1, guest.getId());
            stm.executeUpdate();
            connection.commit();
            return guest;
        }
        catch (SQLException throwables)
        {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

}
