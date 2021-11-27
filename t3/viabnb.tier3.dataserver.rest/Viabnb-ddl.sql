DROP SCHEMA IF EXISTS viabnb CASCADE;
CREATE SCHEMA viabnb;
SET SCHEMA 'viabnb';

CREATE TABLE IF NOT EXISTS Admin
(
    adminId     serial,
    fName       VARCHAR,
    lName       VARCHAR,
    email       VARCHAR,
    phoneNumber VARCHAR,
    password    VARCHAR,
    PRIMARY KEY (adminId)
);

CREATE TABLE IF NOT EXISTS Host
(
    hostId        serial,
    fName         VARCHAR,
    lName         VARCHAR,
    email         VARCHAR,
    phoneNumber   VARCHAR,
    password      VARCHAR,
    cprNumber     VARCHAR,
    isApproved    BOOLEAN,
    personalImage VARCHAR,
    PRIMARY KEY (hostID)
);

CREATE TABLE IF NOT EXISTS City
(
    cityId   serial,
    cityName VARCHAR,
    zipcode  INT,
    PRIMARY KEY (cityId)
);

CREATE TABLE IF NOT EXISTS Address
(
    addressId    serial,
    streetName   VARCHAR,
    streetNumber VARCHAR,
    houseNumber  VARCHAR,
    cityId       INT,
    PRIMARY KEY (addressId),
    FOREIGN KEY (cityId) REFERENCES City (cityId)
);

CREATE TABLE IF NOT EXISTS Residence
(
    residenceId   serial,
    addressId     INT,
    type          VARCHAR,
    description   VARCHAR,
    isAvailable   BOOLEAN,
    pricePrNight  DECIMAL,
    availableFrom DATE,
    availableTo   DATE,
    imageUrl      VARCHAR,
    hostId        INT,
    PRIMARY KEY (residenceId),
    FOREIGN KEY (addressId) REFERENCES Address (addressId),
    FOREIGN KEY (hostId) REFERENCES Host (hostid)
);

CREATE TABLE IF NOT EXISTS Facility
(
    facilityId serial,
    name       VARCHAR,
    PRIMARY KEY (facilityId)
);

CREATE TABLE IF NOT EXISTS RentRequest
(
    rentRequestId  serial,
    startDate      Date,
    endDate        DATE,
    numberOfGuests INT,
    status         VARCHAR,
    hostId         INT,
    PRIMARY KEY (rentRequestId),
    FOREIGN KEY (hostId) REFERENCES Host (hostid)
);

CREATE TABLE IF NOT EXISTS Rule
(
    ruleDescription VARCHAR,
    residenceId     INT,
    PRIMARY KEY (residenceId, ruleDescription),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceId)
);

CREATE TABLE IF NOT EXISTS Guest
(
    guestId         serial,
    viaId           INT,
    isApprovedGuest BOOLEAN,
    PRIMARY KEY (guestId),
    FOREIGN KEY (guestId) REFERENCES Host (hostid) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS GuestReview
(
    guestRating     DECIMAL,
    guestReviewText VARCHAR,
    hostId          INT,
    guestId         INT,
    PRIMARY KEY (hostId, guestId),
    FOREIGN KEY (hostId) REFERENCES Host (hostid),
    FOREIGN KEY (guestId) REFERENCES Guest (guestId)
);

CREATE TABLE IF NOT EXISTS HostReview
(
    hostRating     DECIMAL,
    hostReviewText VARCHAR,
    hostId         INT,
    guestId        INT,
    PRIMARY KEY (hostId, guestId),
    FOREIGN KEY (hostId) REFERENCES Host (hostid),
    FOREIGN KEY (guestId) REFERENCES Guest (guestId)
);

CREATE TABLE IF NOT EXISTS ResidenceReview
(
    residenceRating     DECIMAL,
    residenceReviewText VARCHAR,
    residenceId         INT,
    guestId             INT,
    PRIMARY KEY (residenceId, guestId),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceId),
    FOREIGN KEY (guestId) REFERENCES Guest (guestId)
);

CREATE TABLE IF NOT EXISTS ResidenceFacility
(
    facilityId  INT,
    residenceId INT,
    PRIMARY KEY (facilityId, residenceId),
    FOREIGN KEY (facilityId) REFERENCES Facility (facilityId),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceId)
);

CREATE TABLE IF NOT EXISTS Rent
(
    guestId       INT,
    RentRequestId INT,
    residenceId   INT,
    PRIMARY KEY (guestId, residenceId),
    FOREIGN KEY (guestId) REFERENCES Guest (guestId),
    FOREIGN KEY (RentRequestId) REFERENCES RentRequest (rentRequestId),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceId)
);




