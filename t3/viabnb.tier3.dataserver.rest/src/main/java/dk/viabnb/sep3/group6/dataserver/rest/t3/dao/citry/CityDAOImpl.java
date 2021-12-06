package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.citry;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.City;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class CityDAOImpl extends BaseDao implements CityDAO {
    @Override
    public City getCityById(int id) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement
                    ("SELECT * FROM city WHERE cityid = ?");
            stm.setInt(1, id);

            ResultSet result = stm.executeQuery();
            if (result.next()) {
                return new City
                        (
                                result.getInt("cityId"),
                                result.getString("cityname"),
                                result.getInt("zipcode")
                        );
            }
            return null;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public City createNewCity(City city) {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement
                    ("INSERT INTO city(cityname, zipcode) VALUES (?,?)");
            stm.setString(1, city.getCityName());
            stm.setInt(2, city.getZipCode());
            stm.executeUpdate();
            connection.commit();
            return city;
        } catch (SQLException throwables) {
            throw new IllegalStateException(throwables.getMessage());
        }
    }

    @Override
    public List<City> getAll() {
        try (Connection connection = getConnection()) {
            PreparedStatement stm = connection.prepareStatement("SELECT * from city");
            ResultSet result = stm.executeQuery();
            List<City> cities = new ArrayList<>();
            while (result.next()) {
                City city = new City(
                        result.getInt("cityId"),
                        result.getString("cityname"),
                        result.getInt("zipcode")
                );
                cities.add(city);
            }
            return cities;
        } catch (SQLException throwables) {
            throwables.printStackTrace();
            throw new IllegalStateException(throwables.getMessage());
        }
    }

}
