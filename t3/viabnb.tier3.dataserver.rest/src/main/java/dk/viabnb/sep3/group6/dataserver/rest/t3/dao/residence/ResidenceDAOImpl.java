package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;
//TODO: We need ResidenceRating model class and DAO to implement this

public class ResidenceDAOImpl extends BaseDao implements ResidenceDAO {
    private AddressDAO addressDAO = new AddressDAOImpl();

    @Override
    public Residence getByResidenceId(int id) {
        return null;
    }

    @Override
    public List<Residence> getAllResidenceByHostId(int id) {
        List<Residence> residences = new ArrayList<>();
        try (Connection connection = getConnection()) {
            //residence object
            PreparedStatement stm = connection.prepareStatement(
                    "select *" +
                            "from address," +
                            "     residence," +
                            "     city," +
                            "     host, " +
                            "     facility," +
                            "     rule," +
                            "     residencereview" +
                            " where host.hostid = ?" +
                            "  and host.hostid = residence.hostid" +
                            "  and residence.addressid = address.addressid" +
                            "  and address.cityid = city.cityid" +
                            "  and residence.residenceid = facility.facilityid" +
                            "  and rule.residenceid = residence.residenceid" +
                            "  and residencereview.residenceid = residence.residenceid");
            stm.setInt(1, id);
            ResultSet result = stm.executeQuery();


            while (result.next()) {
                  /*TODO:
                        1. Create Host from query result.
                        2. Create list of facilities from query result
                        3. Create list of rules from query result
                        4. Create Residence from query result
                        Might have to split into multiple queries to get the list of rules and facilities? yup
                */


                City city = new City(result.getInt("city.cityid"),result.getString("cityname"),result.getInt("zipcode"));
                Address address = new Address(result.getInt("address.adressid"), result.getString("streetname"),result.getString("housenumber"),result.getString("streetnumber"),city);

             //   Residence residence = new Residence(result.getInt("residenceid"), result.getObject("addressid"), result.getString("description"));
              //  residences.add(residence);
            }
            return residences;
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    @Override
    public Residence createResidence(Residence residence) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "INSERT INTO residence(addressid, type, description, isavailable, priceprnight, availablefrom, availableto, imageurl, hostid) VALUES(?,?,?,?,?,?,?,?,?)");
            stm.setInt(1, residence.getAddress().getId());
            stm.setString(2, residence.getType());
            stm.setString(3, residence.getDescription());
            stm.setBoolean(4, residence.isAvailable());
            stm.setDouble(5, residence.getPricePerNight());
            stm.setDate(6, (Date) residence.getAvailableFrom());
            stm.setDate(7, (Date) residence.getAvailableTo());
            stm.setString(8, residence.getImageURL());
            stm.setInt(9, residence.getHost().getId());
            stm.executeUpdate();
            connection.commit();
            return residence;
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    @Override
    public List<Residence> getAllResidences()
            throws IllegalStateException {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * from residence"
                            + " join address a on a.addressid = residence.addressid "
                            + "join city c on c.cityid = a.cityid "
                            + " join host h on residence.hostid = h.hostid");
            ResultSet result = stm.executeQuery();
            List<Residence> residences = new ArrayList<>();
            while (result.next()) {
                City city = new City(result.getInt("city.cityid"),result.getString("cityname"),result.getInt("zipcode"));
                Address address = new Address(result.getInt("address.adressid"), result.getString("streetname"),result.getString("housenumber"),result.getString("streetnumber"),city);
                List<Facility> residenceFacilities = getFacilitiesByResidenceId(result.getInt("residenceid"));
                List<Rule> residenceRules = getRulesByResidenceId(result.getInt("residenceid"));
                List<ResidenceReview> residenceReviews = getResidenceReviewsByResidenceId(result.getInt("residenceid"));
                //TODO: fetch the host reviews instead of just using a new List.
                Host residenceHost = new Host(result.getInt("hostid"), result.getString("fname"),
                        result.getString("lname"), result.getString("phonenumber"),
                        result.getString("email"), result.getString("password"), new ArrayList<>(),
                        null, result.getString("cprnumber"),result.getBoolean("isapproved"));
                Residence residence = new Residence(result.getInt("residenceid"),address,
                        result.getString("description"), result.getString("type"),
                        result.getBoolean("isavailable"), result.getDouble("priceprnight"),
                        residenceRules, residenceFacilities, result.getString("imageurl"),
                        result.getDate("availablefrom"), result.getDate("availableto"),
                        result.getInt("maxnumberofguests"),residenceHost, residenceReviews  );
                residences.add(residence);
            }
            return residences;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }
    private List<ResidenceReview> getResidenceReviewsByResidenceId(int residenceId){
        try (Connection connection = getConnection()){
            //TODO: implement this later when we work on review system, for now it just returns empty list.
            return new ArrayList<>();
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
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

    private List<Facility> getFacilitiesByResidenceId(int residenceId){
        try (Connection connection = getConnection()){
            PreparedStatement stm = connection.prepareStatement("SELECT * FROM residencefacility rf join facility f on f.facilityid = rf.facilityid where residenceid = ?");
            stm.setInt(1, residenceId);
            ResultSet results = stm.executeQuery();
            List<Facility> facilities = new ArrayList<>();
            while (results.next()){
                Facility facility = new Facility(results.getInt("facilityid"), results.getString("name"));
                facilities.add(facility);
            }
            return facilities;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    private Facility getFacilityById(int facilityId) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * FROM facility WHERE facilityid = ?");
            stm.setInt(1, facilityId);
            ResultSet result = stm.executeQuery();
            if (result.next()) {
                return new Facility(result.getInt("facilityid"),
                        result.getString("name"));
            }
            throw new IllegalArgumentException("Facility cant be null");
        } catch (SQLException throwables) {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    private List<Facility> getAllFacilities() {
        List<Facility> facilityListToReturn = new ArrayList<>();
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "SELECT * FROM facility");
            ResultSet result = stm.executeQuery();
            while (result.next()) {
                Facility facility = new Facility(result.getInt("facilityid"),
                        result.getString("name"));
                facilityListToReturn.add(facility);
            }
            return facilityListToReturn;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }
}
