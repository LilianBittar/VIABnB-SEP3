package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.Impl;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Guest;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
@Scope("singleton")
public class HostDAOImpl implements HostDAO
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

    @Override public Host approveGuest(Guest guest)
    {
        return null;
    }

    @Override public Host rejectGuest(Guest guest)
    {
        return null;
    }
}
