package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;

import java.util.List;

public interface AddressDAO
{
  /**
   * Return an Address object based on a given id
   * @param addressId The targeted address' id
   * @return Address Object
   * @throws IllegalStateException if can't connect to database
   * */
  Address getAddressById(int addressId);
  /**
   * Create a new address object
   * @param address The new address object
   * @return the newly created object
   *
   * @throws IllegalStateException if can't connect to database
   * */
  Address creteNewAddress(Address address);
  /**
   * Returns all addresses
   * @return {@code List<Address>} with all addresses
   *
   * @throws IllegalStateException if connection to data source failed.
   */
  List<Address> getAll();
}
