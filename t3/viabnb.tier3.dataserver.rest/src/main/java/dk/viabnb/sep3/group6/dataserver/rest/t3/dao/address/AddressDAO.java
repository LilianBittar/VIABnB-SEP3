package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;

import java.util.List;

public interface AddressDAO
{
  /**
   * Create a new Address object and store it in the database
   *
   * @param address The new address object
   * @return the newly created object
   * @throws IllegalStateException if connection to database failed or executing the update is failed
   */
  Address creteNewAddress(Address address);
  /**
   * Query all Address objects in the database
   *
   * @return a list of Address objects
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Address> getAll();
}
