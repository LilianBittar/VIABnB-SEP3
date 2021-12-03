package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

import java.time.LocalDate;
import java.util.Date;

public class RentRequest {
    private int id;
    private LocalDate startDate;
    private LocalDate endDate;
    private int numberOfGuests;
    private RentRequestStatus status;
    private Guest guest;
    private Residence residence;
    private LocalDate requestCreationDate;

    public RentRequest(int id, LocalDate startDate, LocalDate endDate, int numberOfGuests, RentRequestStatus status, Guest guest, Residence residence, LocalDate requestCreationDate) {
        this.id = id;
        this.startDate = startDate;
        this.endDate = endDate;
        this.numberOfGuests = numberOfGuests;
        this.status = status;
        this.guest = guest;
        this.residence = residence;
        this.requestCreationDate = requestCreationDate;
    }

    public RentRequest() {
    }

    public int getId() {
        return id;
    }

    public LocalDate getStartDate() {
        return startDate;
    }

    public LocalDate getEndDate() {
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

    public void setStartDate(LocalDate startDate) {
        this.startDate = startDate;
    }

    public void setEndDate(LocalDate endDate) {
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

    public LocalDate getRequestCreationDate()
    {
        return requestCreationDate;
    }

    public void setRequestCreationDate(LocalDate requestCreationDate)
    {
        this.requestCreationDate = requestCreationDate;
    }
}


