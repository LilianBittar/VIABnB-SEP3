package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;

import java.util.List;

public interface GuestReviewDAO
{
  GuestReview createGuestReview(GuestReview guestReview);
  GuestReview updateGuestReview(GuestReview guestReview);
  List<GuestReview> getAllGuestReviewsByGuestId(int id);
}
