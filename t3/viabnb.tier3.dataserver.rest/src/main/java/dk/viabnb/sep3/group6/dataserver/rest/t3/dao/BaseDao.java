package dk.viabnb.sep3.group6.dataserver.rest.t3.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class BaseDao
{
  protected Connection getConnection() throws SQLException
  {
    Connection result = DriverManager.getConnection(
        "jdbc:postgresql://hattie.db.elephantsql.com:5432/hebcxvqa?currentSchema=viabnb",
        "hebcxvqa", "sLY8ygJklmdHewJNp6sZxN1CZts8zmRD");
    result.setAutoCommit(false);
    return result;
  }
}
