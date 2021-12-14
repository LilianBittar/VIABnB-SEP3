package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.message.MessageDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Message;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController public class MessageController
{
  private final Logger LOGGER = LoggerFactory.getLogger(
      MessageController.class);
  private MessageDAO messageDAO;

  @Autowired public MessageController(MessageDAO messageDAO)
  {
    this.messageDAO = messageDAO;
  }

  @PostMapping("/messages") public ResponseEntity<Message> create(
      @RequestBody Message message)
  {
    LOGGER.info("POST request received for /messages");
    if (message == null)
    {
      return ResponseEntity.badRequest().build();
    }
    try
    {
      Message createdMessage = messageDAO.createMessage(message);
      if (createdMessage == null)
      {
        return ResponseEntity.internalServerError().build();
      }
      return ResponseEntity.ok(createdMessage);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @GetMapping("/messages") public ResponseEntity<List<Message>> getAll()
  {
    LOGGER.info("GET request received for /messages");
    try
    {
      return ResponseEntity.ok(messageDAO.getAllMessages());
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }
}
