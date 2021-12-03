package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.BaseDao;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;

public class GuestReviewDAOImpl extends BaseDao implements GuestReviewDAO
{
  private static final Logger LOGGER= LoggerFactory.getLogger(GuestReviewDAO.class);

  @Override public GuestReview createGuestReview(GuestReview guestReview)
  {
    return null;
  }

  @Override public GuestReview updateGuestReview(GuestReview guestReview)
  {
    return null;
  }

  @Override public List<GuestReview> getAllGuestReviewsByGuestId(int id)
  {
    return null;
  }
}
