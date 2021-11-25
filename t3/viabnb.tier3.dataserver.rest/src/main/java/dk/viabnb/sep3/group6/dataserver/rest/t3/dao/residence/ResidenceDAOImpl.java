package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAOImpl;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
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
    public Residence createResidence(Residence residence) {
        return null;
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
}
