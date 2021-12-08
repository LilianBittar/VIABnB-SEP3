package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.guestreview.GuestReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.GuestReview;
import org.junit.jupiter.api.BeforeEach;

import java.time.LocalDate;

import static org.mockito.Mockito.mock;

class GuestReviewControllerTest
{
  private GuestReviewDAO guestReviewDAO;
  private GuestReviewController guestReviewController;
  private GuestReview guestReview;

  @BeforeEach
  public void setUp()
  {
    guestReviewDAO = mock(GuestReviewDAO.class);
    guestReviewController = new GuestReviewController(guestReviewDAO);
    guestReview = new GuestReview
        (
          3.5,
          "Test",
          LocalDate.now(),
                1,
                1
        );
  }

}