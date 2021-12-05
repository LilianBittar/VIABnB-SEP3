package dk.viabnb.sep3.group6.dataserver.rest.t3.dao.hostreview;

import dk.viabnb.sep3.group6.dataserver.rest.t3.models.HostReview;

import java.util.List;

public interface HostReviewDAO {
    /**
     * Method to create a new HostReview object and store it in a database
     *
     * @param hostReview The new object
     * @return newly created HostReview object
     *
     * @throws IllegalArgumentException if can't connect to database
     * */
    HostReview createHostReview(HostReview hostReview);
    /**
     * Method to update a HostReview object and store it in a database
     *
     * @param hostReview The new updated object
     * @return newly updated HostReview object
     *
     * @throws IllegalArgumentException if can't connect to database
     * */
    HostReview updateHostReview(HostReview hostReview);
    /**
     * Method that query a list of host reviews
     * @param id The id of the host whom the reviews belongs to
     * @return A list of HostReviews objects with a host id that matches the given parameter
     *
     * @throws IllegalArgumentException if can't connect to database
     * */
    List<HostReview> getAllHostReviewsByHostId(int id);
}
