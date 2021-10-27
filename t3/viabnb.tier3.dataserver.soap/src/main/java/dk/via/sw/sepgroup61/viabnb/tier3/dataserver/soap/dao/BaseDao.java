package dk.via.sw.sepgroup61.viabnb.tier3.dataserver.soap.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class BaseDao
{
  protected Connection getConnection() throws SQLException
  {
    Connection result = DriverManager.getConnection(
        "jdbc:postgresql://localhost:5432/postgres?currentSchema=viabnb",
        "postgres", "MichaelDatabasePassword");
    result.setAutoCommit(false);
    return result;
  }
}
