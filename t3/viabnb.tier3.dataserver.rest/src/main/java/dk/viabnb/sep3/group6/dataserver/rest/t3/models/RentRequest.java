package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Date;

public class RentRequest {
    private int id;
    private Date startDate;
    private Date endDate;
    private int numberOfGuests;
    private RentRequestStatus status;
    private Guest guest;
    private Residence residence;

    public RentRequest(int id, Date startDate, Date endDate, int numberOfGuests, RentRequestStatus status, Guest guest, Residence residence) {
        this.id = id;
        this.startDate = startDate;
        this.endDate = endDate;
        this.numberOfGuests = numberOfGuests;
        this.status = status;
        this.guest = guest;
        this.residence = residence;
    }

    public RentRequest() {
    }

    public int getId() {
        return id;
    }

    public Date getStartDate() {
        return startDate;
    }

    public Date getEndDate() {
        return endDate;
    }

    public int getNumberOfGuests() {
        return numberOfGuests;
    }

    public RentRequestStatus getStatus() {
        return status;
    }

    public Guest getGuest() {
        return guest;
    }

    public Residence getResidence() {
        return residence;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setStartDate(Date startDate) {
        this.startDate = startDate;
    }

    public void setEndDate(Date endDate) {
        this.endDate = endDate;
    }

    public void setNumberOfGuests(int numberOfGuests) {
        this.numberOfGuests = numberOfGuests;
    }

    public void setStatus(RentRequestStatus status) {
        this.status = status;
    }

    public void setGuest(Guest guest) {
        this.guest = guest;
    }

    public void setResidence(Residence residence) {
        this.residence = residence;
    }
}


