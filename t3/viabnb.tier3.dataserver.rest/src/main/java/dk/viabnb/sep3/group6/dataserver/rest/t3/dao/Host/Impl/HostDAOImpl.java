package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

@Repository
@Scope("singleton")
public class HostDAOImpl extends BaseDao implements HostDAO
{

    @Override
    public Host RegisterHost(Host host) {
        return null;
    }

    @Override public Host getHostByEmail(String email)
    {
        return null;
    }

    @Override public Host getHostById(int Id)
    {
        return null;
    }

    @Override public List<Host> getAllHosts()
    {
        return null;
    }

    @Override public List<Host> getAllNotApprovedHosts()
    {
        List<Host> hostsToReturn = new ArrayList<>();
        try(Connection connection = getConnection())
        {
            PreparedStatement stm = connection.prepareStatement
                ("SELECT * FROM viabnb.host WHERE isapproved = ?");
            stm.setBoolean(1, false);
            ResultSet result = stm.executeQuery();
            while (result.next())
            {
                Host hostToAdd = new Host
                    (
                        result.getInt("hostid"),
                        result.getString("fname"),
                        result.getString("lname"),
                        result.getString("phonenumber"),
                        result.getString("email"),
                        result.getString("password"),
                        null,
                        result.getString("personalimage"),
                        result.getString("cprnumber"),
                        result.getBoolean("isapproved")
                    );
            }
        }
        catch (SQLException throwables)
        {
            throwables.printStackTrace();
        }
        return null;
    }

    @Override public Host approveGuest(Guest guest)
    {
        return null;
    }

    @Override public Host rejectGuest(Guest guest)
    {
        return null;
    }
}
