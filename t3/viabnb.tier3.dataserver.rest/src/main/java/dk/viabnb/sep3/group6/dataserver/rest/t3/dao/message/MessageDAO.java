package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.message;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Message;

import java.util.List;

public interface MessageDAO {
    public Message create(Message message);
    public List<Message> getAll();
}
