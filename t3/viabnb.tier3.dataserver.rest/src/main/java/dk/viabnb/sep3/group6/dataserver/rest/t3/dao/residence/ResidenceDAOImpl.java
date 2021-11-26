package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Facility;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Rule;
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
        return null;
    }

    @Override
    public Residence createResidence(Residence residence)
    {
        try(Connection connection = getConnection())
        {
            PreparedStatement stm = connection.prepareStatement
                ("INSERT INTO residence(addressid, type, description, isavailable, priceprnight, availablefrom, availableto, imageurl, hostid) VALUES(?,?,?,?,?,?,?,?,?)");
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
        }
        catch (SQLException throwables)
        {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    @Override
    public List<Residence> getAllResidences() throws IllegalStateException {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("SELECT * from residence" +
                    " join address a on a.addressid = residence.addressid " +
                    "join city c on c.cityid = a.cityid " +
                    "join residencefacility r on residence.residenceid = r.residenceid " +
                    "join rule r2 on residence.residenceid = r2.residenceid" +
                    " join host h on residence.hostid = h.hostid" );
            ResultSet result = stm.executeQuery();
            while (result.next()){
                /*TODO: 1. Create Host from query result.
                        2. Create City from query result.
                        3. Create Address from query result.
                        4. Create list of facilities from query result
                        5. Create list of rules from query result
                        6. Create Residence from query result
                        Might have to split into multiple queries to get the list of rules and facilities?
                */

            }
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }

        return null;
    }

    private List<Rule> getRulesByResidenceId(int residenceId)
    {
        List<Rule> ruleListToReturn = new ArrayList<>();
        try(Connection connection = getConnection())
        {
            PreparedStatement stm = connection.prepareStatement
                ("SELECT * FROM rule WHERE residenceid = ?");
            stm.setInt(1, residenceId);
            ResultSet result = stm.executeQuery();
            while (result.next())
            {
                Rule rule = new Rule
                    (
                        result.getString("ruledescription"),
                        result.getInt("residenceid")
                    );
                ruleListToReturn
                    .add(rule);
            }
            return ruleListToReturn;
        }
        catch (SQLException throwables)
        {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    private Facility getFacilityById(int facilityId)
    {
        try(Connection connection = getConnection())
        {
            PreparedStatement stm = connection.prepareStatement
                ("SELECT * FROM facility WHERE facilityid = ?");
            stm.setInt(1, facilityId);
            ResultSet result = stm.executeQuery();
            result.next();
            return new Facility
                (
                    result.getInt("facilityid"),
                    result.getString("name")
                );
        }
        catch (SQLException throwables)
        {
            throw new IllegalArgumentException(throwables.getMessage());
        }
    }

    private List<Facility> getAllFacilities()
    {
        List<Facility> facilityListToReturn = new ArrayList<>();
        try(Connection connection = getConnection())
        {
            PreparedStatement stm = connection.prepareStatement
                ("SELECT * FROM facility");
            ResultSet result = stm.executeQuery();
            while (result.next())
            {
                Facility facility = new Facility
                    (
                        result.getInt("facilityid"),
                        result.getString("name")
                    );
                facilityListToReturn.add(facility);
            }
            return facilityListToReturn;
        }
        catch (SQLException throwables)
        {
            throw new IllegalStateException(throwables.getMessage());
        }
    }
}
