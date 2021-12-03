package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest;

import com.google.gson.Gson;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.webjars.NotFoundException;

import java.sql.*;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class RentRequestDAOImpl extends BaseDao implements RentRequestDAO {
    private final Logger LOGGER = LoggerFactory.getLogger(
            RentRequestDAOImpl.class);

    @Override
    public RentRequest create(RentRequest request) {
        try (Connection connection = getConnection()) {
            // TODO: Change DDL to have guestId instead of hostid and residenceid as foreign key to residence
            // BUG: SQL Cannot parse Util.Date, but can parse LocalDate form the time / JodaTime library.

            PreparedStatement stm = connection.prepareStatement(
                    "insert into rentrequest(startdate, enddate, numberofguests, status, hostid, residenceid, guestid, createdate) values (?,?,?,?,?,?,?,?)");
            LOGGER.info("statement set");
            stm.setDate(1, Date.valueOf(request.getStartDate()));
            stm.setDate(2, Date.valueOf(request.getEndDate()));
            stm.setInt(3, request.getNumberOfGuests());
            stm.setString(4, RentRequestStatus.NOTANSWERED.name());
            stm.setInt(5, request.getResidence().getHost().getId());
            stm.setInt(6, request.getResidence().getId());
            stm.setInt(7, request.getGuest().getId());
            stm.setDate(8, Date.valueOf(request.getRequestCreationDate()));
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
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * FROM rentrequest JOIN host h on h.hostid = rentrequest.hostid JOIN _user u ON u.userid = h.hostid WHERE rentrequestid = ?");
            stm.setInt(1, id);
            ResultSet result = stm.executeQuery();
            if (result.next()) {
                return new RentRequest(result.getInt("rentrequestid"),
                        LocalDate.parse(result.getDate("startdate").toString()),
                        LocalDate.parse(result.getDate("enddate").toString()),
                        result.getInt("numberofguests"),
                        RentRequestStatus.valueOf(result.getString("status")),
                        getGuestById(result.getInt("guestid")),
                        getResidenceById(result.getInt("hostid")), LocalDate.parse(result.getDate("createdate").toString()));
            }
            throw new IllegalArgumentException("Rent request is null");
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    @Override
    public List<RentRequest> getAll() {
        List<RentRequest> rentRequestListToReturn = new ArrayList<>();
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * FROM rentrequest JOIN residence r on r.residenceid = rentrequest.residenceid JOIN address a on a.addressid = r.addressid JOIN city c on c.cityid = a.cityid JOIN _user u on u.userid = r.hostid JOIN host h on h.hostid = rentrequest.hostid JOIN guest g on h.hostid = g.guestid");
            ResultSet result = stm.executeQuery();
            while (result.next()) {
                City city = new City
                        (
                                result.getInt("cityid"),
                                result.getString("cityname"),
                                result.getInt("zipcode")
                        );
                Address address = new Address
                        (
                                result.getInt("addressid"),
                                result.getString("streetname"),
                                result.getString("housenumber"),
                                result.getString("streetnumber"),
                                city
                        );
                Host host = new Host
                        (
                                result.getInt("userid"),
                                result.getString("email"),
                                result.getString("password"),
                                result.getString("fname"),
                                result.getString("lname"),
                                result.getString("phonenumber"),
                                new ArrayList<>(),
                                result.getString("personalimage"),
                                result.getString("cprnumber"),
                                result.getBoolean("isapproved")
                        );
                Residence residence = new Residence(result.getInt("residenceid"), address,
                        result.getString("description"), result.getString("type"),
                        result.getBoolean("isavailable"), result.getDouble("priceprnight"),
                        getRulesByResidenceId(result.getInt("residenceid")), getFacilitiesByResidenceId(result.getInt("residenceid")), result.getString("imageurl"),
                        LocalDate.parse(result.getDate("availablefrom").toString()), LocalDate.parse(result.getDate("availableto").toString()),
                        result.getInt("maxnumberofguests"), host, new ArrayList<>());

                RentRequest request = new RentRequest(result.getInt("rentrequestid"),
                        LocalDate.parse(result.getDate("startdate").toString()),
                        LocalDate.parse(result.getDate("enddate").toString()),
                        result.getInt("numberofguests"),
                        RentRequestStatus.valueOf(result.getString("status")),
                        getGuestById(result.getInt("guestid")),
                        residence, LocalDate.parse(result.getDate("createdate").toString()));
                rentRequestListToReturn.add(request);
            }
            return rentRequestListToReturn;
        } catch (SQLException throwables) {
            throw new NotFoundException(throwables.getMessage());
        }
    }

    @Override
    public RentRequest approveRequest(RentRequest request) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "UPDATE rentrequest SET status = 'APPROVED' WHERE rentrequestid = ?");
            stm.setInt(1, request.getId());
            stm.executeUpdate();
            connection.commit();
            return request;
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    @Override
    public RentRequest rejectRequest(RentRequest request) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "UPDATE rentrequest SET status = 'NOTAPPROVED' WHERE rentrequestid = ?");
            stm.setInt(1, request.getId());
            stm.executeUpdate();
            connection.commit();
            return request;
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    private Guest getGuestById(int id) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * FROM _user JOIN host h ON _user.userid = h.hostid JOIN guest g ON h.hostid = g.guestid WHERE userid = ?");
            stm.setInt(1, id);
            ResultSet result = stm.executeQuery();
            if (result.next()) {
                return new Guest(result.getInt("userid"), result.getString("email"),
                        result.getString("password"), result.getString("fname"),
                        result.getString("lname"), result.getString("phonenumber"),
                        new ArrayList<>(), result.getString("personalimage"),
                        result.getString("cprnumber"), result.getBoolean("isapproved"),
                        result.getInt("viaid"), new ArrayList<>(),
                        result.getBoolean("isapprovedguest"));
            }
            return null;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    private Residence getResidenceById(int id) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * FROM residence JOIN address a on a.addressid = residence.addressid JOIN city c on c.cityid = a.cityid JOIN _user u on u.userid = residence.hostid JOIN host h on u.userid = h.hostid WHERE residenceid = ?");
            stm.setInt(1, id);
            ResultSet result = stm.executeQuery();
            if (result.next()) {
                City city = new City
                        (
                                result.getInt("cityid"),
                                result.getString("cityname"),
                                result.getInt("zipcode")
                        );
                Address address = new Address
                        (
                                result.getInt("addressid"),
                                result.getString("streetname"),
                                result.getString("housenumber"),
                                result.getString("streetnumber"),
                                city
                        );
                Host host = new Host
                        (
                                result.getInt("userid"),
                                result.getString("email"),
                                result.getString("password"),
                                result.getString("fname"),
                                result.getString("lname"),
                                result.getString("phonenumber"),
                                new ArrayList<>(),
                                result.getString("personalimage"),
                                result.getString("cprnumber"),
                                result.getBoolean("isapproved")
                        );
                return new Residence(result.getInt("residenceid"), address,
                        result.getString("description"), result.getString("type"),
                        result.getBoolean("isavailable"), result.getDouble("priceprnight"),
                        getRulesByResidenceId(result.getInt("residenceid")), getFacilitiesByResidenceId(result.getInt("residenceid")), result.getString("imageurl"),
                        LocalDate.parse(result.getDate("startdate").toString()),
                        LocalDate.parse(result.getDate("enddate").toString()),
                        result.getInt("maxnumberofguests"), host, new ArrayList<>());
            }
            return null;
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    private Host getHostByUserId(int id) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement
                    ("SELECT * FROM host JOIN _user u on u.userid = host.hostid WHERE userid = ?");
            stm.setInt(1, id);
            ResultSet result = stm.executeQuery();
            if (result.next()) {
                return new Host(result.getInt("userid"), result.getString("email"),
                        result.getString("password"), result.getString("fname"),
                        result.getString("lname"), result.getString("phonenumber"),
                        new ArrayList<>(), result.getString("personalimage"),
                        result.getString("cprnumber"), result.getBoolean("isapproved"));
            }
            return null;
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    private List<Rule> getRulesByResidenceId(int residenceId) {
        List<Rule> ruleListToReturn = new ArrayList<>();
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * FROM rule WHERE residenceid = ?");
            stm.setInt(1, residenceId);
            ResultSet result = stm.executeQuery();
            while (result.next()) {
                Rule rule = new Rule(result.getString("ruledescription"),
                        result.getInt("residenceid"));
                ruleListToReturn.add(rule);
            }
            return ruleListToReturn;
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    private List<Facility> getFacilitiesByResidenceId(int residenceId) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * FROM residencefacility rf join facility f on f.facilityid = rf.facilityid where residenceid = ?");
            stm.setInt(1, residenceId);
            ResultSet results = stm.executeQuery();
            List<Facility> facilities = new ArrayList<>();
            while (results.next()) {
                Facility facility = new Facility(results.getInt("facilityid"),
                        results.getString("name"));
                facilities.add(facility);
            }
            return facilities;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }
}
