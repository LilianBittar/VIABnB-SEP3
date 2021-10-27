package dk.viabnb.sep3.group6.dataserver.soapws.t3.endpoints;

import dk.viabnb.sep3.group6.dataserver.soapws.t3.models.ConceptMessage;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;

@WebService
@SOAPBinding(style = SOAPBinding.Style.RPC)
public interface ConceptMessageService
{
  @WebMethod ConceptMessage getConceptMessage(int id);
}
