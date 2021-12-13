package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.*;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class ResidenceDAOImpl extends BaseDao implements ResidenceDAO
{
  @Override public Residence getResidenceById(int id)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM residence JOIN address a on a.addressid = residence.addressid JOIN city c on c"
              + ".cityid = a.cityid JOIN _user u on u.userid = residence.hostid JOIN host h on u.userid ="
              + " h.hostid WHERE residenceid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        City city = new City(result.getInt("cityid"),
            result.getString("cityname"), result.getInt("zipcode"));
        Address address = new Address(result.getInt("addressid"),
            result.getString("streetname"), result.getString("housenumber"),
            result.getString("streetnumber"), city);
        List<Facility> residenceFacilities = getFacilitiesByResidenceId(
            result.getInt("residenceid"));
        List<Rule> residenceRules = getRulesByResidenceId(
            result.getInt("residenceid"));
        List<ResidenceReview> residenceReviews = getResidenceReviewsByResidenceId(
            result.getInt("residenceid"));
        Host residenceHost = new Host(result.getInt("userid"),
            result.getString("email"), result.getString("password"),
            result.getString("fname"), result.getString("lname"),
            result.getString("phonenumber"), result.getString("personalimage"),
            new ArrayList<>(), result.getString("cprnumber"),
            result.getBoolean("isapproved"));
        return new Residence(result.getInt("residenceid"), address,
            result.getString("description"), result.getString("type"),
            result.getBoolean("isavailable"), result.getDouble("priceprnight"),
            residenceRules, residenceFacilities, result.getString("imageurl"),
            LocalDate.parse(result.getDate("availablefrom").toString()),
            LocalDate.parse(result.getDate("availableto").toString()),
            result.getInt("maxnumberofguests"), residenceHost,
            residenceReviews);
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Residence> getAllResidenceByHostId(int id)
      throws IllegalStateException
  {

    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM residence JOIN address a on a"
              + ".addressid = residence.addressid JOIN city c on c.cityid = a.cityid JOIN _user u on u.userid = "
              + "residence.hostid JOIN host h on u.userid = h.hostid WHERE userid = ?");
      stm.setInt(1, id);
      ResultSet result = stm.executeQuery();
      List<Residence> residences = new ArrayList<>();
      while (result.next())
      {
        City city = new City(result.getInt("cityid"),
            result.getString("cityname"), result.getInt("zipcode"));
        Address address = new Address(result.getInt("addressid"),
            result.getString("streetname"), result.getString("housenumber"),
            result.getString("streetnumber"), city);
        List<Facility> residenceFacilities = getFacilitiesByResidenceId(
            result.getInt("residenceid"));
        List<Rule> residenceRules = getRulesByResidenceId(
            result.getInt("residenceid"));
        List<ResidenceReview> residenceReviews = getResidenceReviewsByResidenceId(
            result.getInt("residenceid"));
        Host residenceHost = new Host(result.getInt("hostid"),
            result.getString("email"), result.getString("password"),
            result.getString("fname"), result.getString("lname"),
            result.getString("phonenumber"), result.getString("personalimage"),
            new ArrayList<>(), result.getString("cprnumber"),
            result.getBoolean("isapproved"));
        Residence residence = new Residence(result.getInt("residenceid"),
            address, result.getString("description"), result.getString("type"),
            result.getBoolean("isavailable"), result.getDouble("priceprnight"),
            residenceRules, residenceFacilities, result.getString("imageurl"),
            LocalDate.parse(result.getDate("availablefrom").toString()),
            LocalDate.parse(result.getDate("availableto").toString()),
            result.getInt("maxnumberofguests"), residenceHost,
            residenceReviews);
        residences.add(residence);
      }
      return residences;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }

  }

  @Override public Residence createResidence(Residence residence)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "INSERT INTO residence(addressid, type, description, isavailable, priceprnight, availablefrom, "
              + "availableto, imageurl, hostid, maxnumberofguests) VALUES(?,?,?,?,?,?,?,?,?,?)",
          Statement.RETURN_GENERATED_KEYS);
      stm.setInt(1, residence.getAddress().getId());
      stm.setString(2, residence.getType());
      stm.setString(3, residence.getDescription());
      stm.setBoolean(4, residence.isAvailable());
      stm.setDouble(5, residence.getPricePerNight());
      stm.setDate(6, (Date.valueOf(residence.getAvailableFrom())));
      stm.setDate(7, (Date.valueOf(residence.getAvailableTo())));
      stm.setString(8, residence.getImageUrl());
      stm.setInt(9, residence.getHost().getId());
      stm.setInt(10, residence.getMaxNumberOfGuests());
      stm.executeUpdate();
      connection.commit();
      ResultSet keys = stm.getGeneratedKeys();
      keys.next();
      residence.setId(keys.getInt(1));
      createRuleEntries(residence, residence.getRules());
      createResidenceFacilityEntries(residence, residence.getFacilities());
      return residence;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public List<Residence> getAllResidences()
      throws IllegalStateException
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM residence JOIN address a on a.addressid = residence.addressid JOIN city c on c"
              + ".cityid = a.cityid JOIN _user u on u.userid = residence.hostid JOIN host h on u.userid ="
              + " h.hostid");
      ResultSet result = stm.executeQuery();
      List<Residence> residences = new ArrayList<>();
      while (result.next())
      {
        City city = new City(result.getInt("cityid"),
            result.getString("cityname"), result.getInt("zipcode"));
        Address address = new Address(result.getInt("addressid"),
            result.getString("streetname"), result.getString("housenumber"),
            result.getString("streetnumber"), city);
        List<Facility> residenceFacilities = getFacilitiesByResidenceId(
            result.getInt("residenceid"));
        List<Rule> residenceRules = getRulesByResidenceId(
            result.getInt("residenceid"));
        List<ResidenceReview> residenceReviews = getResidenceReviewsByResidenceId(
            result.getInt("residenceid"));
        Host residenceHost = new Host(result.getInt("hostid"),
            result.getString("email"), result.getString("password"),
            result.getString("fname"), result.getString("lname"),
            result.getString("phonenumber"), result.getString("personalimage"),
            new ArrayList<>(), result.getString("cprnumber"),
            result.getBoolean("isapproved"));
        Residence residence = new Residence(result.getInt("residenceid"),
            address, result.getString("description"), result.getString("type"),
            result.getBoolean("isavailable"), result.getDouble("priceprnight"),
            residenceRules, residenceFacilities, result.getString("imageurl"),
            LocalDate.parse(result.getDate("availablefrom").toString()),
            LocalDate.parse(result.getDate("availableto").toString()),
            result.getInt("maxnumberofguests"), residenceHost,
            residenceReviews);
        residences.add(residence);
      }
      return residences;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Residence updateAvailabilityPeriod(Residence residence)
      throws IllegalStateException
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "update residence " + "set isavailable   = ?," + "availablefrom = ?,"
              + "availableto= ? " + "where residenceid = ?;");

      stm.setBoolean(1, residence.isAvailable());
      stm.setDate(2, (Date.valueOf(residence.getAvailableFrom())));
      stm.setDate(3, (Date.valueOf(residence.getAvailableTo())));
      stm.setInt(4, residence.getId());
      stm.executeUpdate();
      connection.commit();
      return residence;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public Residence updateResidence(Residence residence)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "UPDATE residence SET type = ?, description = ?, "
              + "isavailable = ?, priceprnight = ?, availablefrom = ?,"
              + " availableto = ?, imageurl = ?, maxnumberofguests = ? "
              + "WHERE residenceid = ?");
      stm.setString(1, residence.getType());
      stm.setString(2, residence.getDescription());
      stm.setBoolean(3, residence.isAvailable());
      stm.setDouble(4, residence.getPricePerNight());
      stm.setDate(5, Date.valueOf(residence.getAvailableFrom()));
      stm.setDate(6, Date.valueOf(residence.getAvailableTo()));
      stm.setString(7, residence.getImageUrl());
      stm.setInt(8, residence.getMaxNumberOfGuests());
      stm.setInt(9, residence.getId());
      stm.executeUpdate();
      connection.commit();
      return residence;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  @Override public void deleteResidence(int residenceId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "DELETE FROM residence WHERE residenceid = ?");
      stm.setInt(1, residenceId);
      stm.executeUpdate();
      connection.commit();
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private List<ResidenceReview> getResidenceReviewsByResidenceId(
      int residenceId)
  {
    List<ResidenceReview> residenceReviews = new ArrayList<>();
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM residencereview "
              + "JOIN residence r on r.residenceid = residencereview.residenceid "
              + "JOIN guest g on g.guestid = residencereview.guestid "
              + "WHERE r.residenceid = ?");
      stm.setInt(1, residenceId);
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        ResidenceReview residenceReview = new ResidenceReview(
            result.getDouble("residencerating"),
            result.getString("residencereviewtext"),
            getGuestById(result.getInt("guestid")).getViaId(),
            LocalDate.parse(result.getDate("createddate").toString()));
      }
      return residenceReviews;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private List<Rule> getRulesByResidenceId(int residenceId)
  {
    List<Rule> ruleListToReturn = new ArrayList<>();
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM rule WHERE residenceid = ?");
      stm.setInt(1, residenceId);
      ResultSet result = stm.executeQuery();
      while (result.next())
      {
        Rule rule = new Rule(result.getString("ruledescription"),
            result.getInt("residenceid"));
        ruleListToReturn.add(rule);
      }
      return ruleListToReturn;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private List<Facility> getFacilitiesByResidenceId(int residenceId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM residencefacility rf join facility f on f.facilityid = rf.facilityid where "
              + "residenceid = ?");
      stm.setInt(1, residenceId);
      ResultSet results = stm.executeQuery();
      List<Facility> facilities = new ArrayList<>();
      while (results.next())
      {
        Facility facility = new Facility(results.getInt("facilityid"),
            results.getString("name"));
        facilities.add(facility);
      }
      return facilities;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private void createResidenceFacilityEntries(Residence residence,
      List<Facility> facilities)
  {
    try (Connection connection = getConnection())
    {
      for (Facility facility : facilities)
      {
        PreparedStatement stm = connection.prepareStatement(
            "INSERT INTO residencefacility(residenceid, "
                + "facilityid) values (?,?)");
        stm.setInt(1, residence.getId());
        stm.setInt(2, facility.getId());
        stm.executeUpdate();
      }
      connection.commit();
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalArgumentException(throwables.getMessage());
    }
  }

  private void createRuleEntries(Residence residence, List<Rule> rules)
  {
    try (Connection connection = getConnection())
    {
      for (Rule rule : rules)
      {
        PreparedStatement stm = connection.prepareStatement(
            "INSERT INTO rule(residenceid, ruledescription) " + "values (?,?)");
        stm.setInt(1, residence.getId());
        stm.setString(2, rule.getDescription());
        stm.executeUpdate();
      }
      connection.commit();

    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalArgumentException(throwables.getMessage());
    }
  }

  private Guest getGuestById(int guestId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM _user JOIN host h ON _user.userid = h.hostid JOIN guest g ON h.hostid = g.guestid "
              + "WHERE userid = ?");
      stm.setInt(1, guestId);
      ResultSet result = stm.executeQuery();
      if (result.next())
      {
        List<GuestReview> guestReview = getGuestReviewsByGuestId(guestId);
        List<HostReview> hostReviews = getHostReviewsByHostId(guestId);
        return new Guest(result.getInt("userid"), result.getString("email"),
            result.getString("password"), result.getString("fname"),
            result.getString("lname"), result.getString("phonenumber"),
            result.getString("personalimage"), hostReviews,
            result.getString("cprnumber"), result.getBoolean("isapproved"),
            result.getInt("viaid"), guestReview,
            result.getBoolean("isapprovedguest"));
      }
      return null;
    }
    catch (SQLException throwables)
    {
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private List<HostReview> getHostReviewsByHostId(int hostId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM hostreview where hostid = ?");
      stm.setInt(1, hostId);
      ResultSet result = stm.executeQuery();
      List<HostReview> hostReviews = new ArrayList<>();
      while (result.next())
      {
        HostReview review = new HostReview(result.getInt("hostrating"),
            result.getString("hostreviewtext"), result.getInt("guestid"),
            result.getDate("createddate").toLocalDate(),
            result.getInt("hostid"));
        hostReviews.add(review);
      }
      return hostReviews;
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }

  private List<GuestReview> getGuestReviewsByGuestId(int guestId)
  {
    try (Connection connection = getConnection())
    {
      PreparedStatement stm = connection.prepareStatement(
          "SELECT * FROM guestreview  where guestid = ?");
      stm.setInt(1, guestId);
      ResultSet result = stm.executeQuery();
      List<GuestReview> guestReviews = new ArrayList<>();
      while (result.next())
      {
        GuestReview review = new GuestReview(result.getInt("guestrating"),
            result.getString("guestreviewtext"),
            result.getDate("createddate").toLocalDate(),
            result.getInt("guestid"), result.getInt("hostid"));
        guestReviews.add(review);
      }
      return guestReviews;
    }
    catch (SQLException throwables)
    {
      throwables.printStackTrace();
      throw new IllegalStateException(throwables.getMessage());
    }
  }
}
