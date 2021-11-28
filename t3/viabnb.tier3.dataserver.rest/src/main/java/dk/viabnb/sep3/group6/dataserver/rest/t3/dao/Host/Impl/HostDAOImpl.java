package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guest.GuestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;


public class HostDAOImpl extends BaseDao implements HostDAO
{
    private static final Logger LOGGER= LoggerFactory.getLogger(HostDAO.class);

    @Override
    public Host RegisterHost(Host host) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("insert into host(fname, lname, email, phonenumber, password,cprnumber,isapproved,personalimage) values (?,?,?,?,?,?,?,?)");
            stm.setString(1, host.getFirstName());
            stm.setString(2, host.getLastName());
            stm.setString(3, host.getEmail());
            stm.setString(4, host.getPhoneNumber());
            stm.setString(5, host.getPassword());
            stm.setString(6, host.getCpr());
            stm.setBoolean(7,host.isApprovedHost());
            stm.setString(8,host.getProfileImageUrl());
            stm.executeUpdate();
            connection.commit();
            return host;

        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public Host getHostByEmail(String email) {
        try (Connection connection = getConnection()){
            PreparedStatement stm = connection.prepareStatement(" select * from host where email = ?");
            stm.setString(1, email);
            ResultSet result = stm.executeQuery();
            result.next();
            return new Host(
                    result.getInt("hostid"),
                    result.getString("fname"),
                    result.getString("lname"),
                    result.getString("phonenumber"),
                    result.getString("email"),
                    result.getString("password"),
                    new ArrayList<>(),
                    result.getString("personalimage"),
                    result.getString("cprnumber"),
                    result.getBoolean("isapproved")
            );
        } catch (SQLException throwables){
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public Host getHostById(int Id) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("SELECT * FROM host where hostid = ?");
            stm.setInt(1, Id);
            ResultSet result = stm.executeQuery();
            result.next();
            return new Host
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
                            result.getBoolean("isapproved")
                    );

        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }

    }

    @Override
    public List<Host> getAllHosts() {
        List<Host> hostsToReturn = new ArrayList<>();
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement(
                    "select * from host"
            );
            ResultSet result = stm.executeQuery();
            while (result.next()) {
                Host hostToAdd = new Host
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
                                result.getBoolean("isapproved")
                        );
                hostsToReturn.add(hostToAdd);
            }
            return hostsToReturn;
        }catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public List<Host> getAllNotApprovedHosts() {
        List<Host> hostsToReturn = new ArrayList<>();
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement
                    ("SELECT * FROM host WHERE isapproved = ?");
            stm.setBoolean(1, false);
            ResultSet result = stm.executeQuery();
            while (result.next()) {
                Host hostToAdd = new Host
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
                                result.getBoolean("isapproved")
                        );
                hostsToReturn.add(hostToAdd);
            }
            return hostsToReturn;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public Host approveHost(Host host) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement
                    ("UPDATE host SET isapproved = true WHERE hostid = ?");
            stm.setInt(1, host.getId());
            stm.executeUpdate();
            connection.commit();
            return host;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public Host rejectHost(Host host) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement
                    ("DELETE FROM host WHERE hostid = ?");
            stm.setInt(1, host.getId());
            stm.executeUpdate();
            connection.commit();
            return host;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }
}
