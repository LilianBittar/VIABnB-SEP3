package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.facility;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Facility;

import java.util.List;

public interface FacilityDAO
{
  Facility createFacility(Facility facility);
  List<Facility> getAllFacilities();
  Facility getFacilityById(int id);
}
