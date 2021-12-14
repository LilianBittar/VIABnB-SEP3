package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.message;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Message;

import java.util.List;

public interface MessageDAO
{
  /**
   * Create a new Message object and store it in the database
   *
   * @param message The new message object
   * @return The newly created Message object
   * @throws IllegalStateException if connection to database failed or executing the update failed
   */
  Message createMessage(Message message);
  /**
   * Auery a list of Message objects
   *
   * @return A list o Message objects
   * @throws IllegalStateException if connection to database failed or query execution failed
   */
  List<Message> getAllMessages();
}
