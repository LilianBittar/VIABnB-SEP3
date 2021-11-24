package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;

public interface AddressDAO
{
  /**
   * Return an Address object based on a given id
   * @param addressId The targeted address' id
   * @return Address Object
   * @throws IllegalStateException on SQL failure or invalid id
   * */
  Address getAddressById(int addressId);
}
