package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;

public interface AddressDAO
{
  Address getAddressById(int addressId);
}
