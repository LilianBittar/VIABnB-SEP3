DROP SCHEMA IF EXISTS viabnb CASCADE;
CREATE SCHEMA viabnb;
SET SCHEMA 'viabnb';

CREATE TABLE IF NOT EXISTS _User
(
    userId      serial,
    email       VARCHAR,
    password    VARCHAR,
    fName       VARCHAR,
    lName       VARCHAR,
    phoneNumber VARCHAR,
    PRIMARY KEY (userId)
);

CREATE TABLE IF NOT EXISTS Admin
(
    adminId  serial,
    initials VARCHAR,
    PRIMARY KEY (adminId),
    FOREIGN KEY (adminId) REFERENCES _User (userId)
);

CREATE TABLE IF NOT EXISTS Host
(
    hostId        serial,
    cprNumber     VARCHAR,
    isApproved    BOOLEAN,
    personalImage VARCHAR,
    PRIMARY KEY (hostID),
    FOREIGN KEY (hostId) REFERENCES _User (userId) ON DELETE CASCADE
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
    residenceId       serial,
    addressId         INT,
    type              VARCHAR,
    description       VARCHAR,
    isAvailable       BOOLEAN,
    pricePrNight      DECIMAL,
    availableFrom     DATE,
    availableTo       DATE,
    imageUrl          VARCHAR,
    maxNumberOfGuests INT,
    hostId            INT,
    PRIMARY KEY (residenceId),
    FOREIGN KEY (addressId) REFERENCES Address (addressId),
    FOREIGN KEY (hostId) REFERENCES _user (userid) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Facility
(
    facilityId serial,
    name       VARCHAR,
    PRIMARY KEY (facilityId)
);

CREATE TABLE IF NOT EXISTS Guest
(
    guestId         serial,
    viaId           INT,
    isApprovedGuest BOOLEAN,
    PRIMARY KEY (guestId),
    FOREIGN KEY (guestId) REFERENCES Host (hostid) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS RentRequest
(
    rentRequestId  serial,
    startDate      Date,
    endDate        DATE,
    numberOfGuests INT,
    status         VARCHAR,
    hostId         INT,
    residenceId    INT,
    guestId        Int,
    PRIMARY KEY (rentRequestId),
    FOREIGN KEY (hostId) REFERENCES Host (hostid),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceid),
    foreign key (guestId) references Guest (guestId)
);
CREATE TABLE IF NOT EXISTS Rule
(
    ruleDescription VARCHAR,
    residenceId     INT,
    PRIMARY KEY (residenceId, ruleDescription),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceId)
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

INSERT INTO _User(email, password, fName, lName, phoneNumber)
VALUES ('291597@via.dk', '1234', 'Kutaiba', 'Kashmar', '11111111');
INSERT INTO _User(email, password, fName, lName, phoneNumber)
VALUES ('293885@via.dk', '1234', 'Michael', 'Bui', '22222222');
INSERT INTO _User(email, password, fName, lName, phoneNumber)
VALUES ('304218@via.dk', '1234', 'Kasper', 'Jensen', '33333333');
INSERT INTO _User(email, password, fName, lName, phoneNumber)
VALUES ('293336@via.dk', '1234', 'Lilian', 'Bittar', '44444444');

INSERT INTO Admin(adminId, initials)
VALUES (1, 'KNK');
INSERT INTO Admin(adminId, initials)
VALUES (2, 'MTB');
INSERT INTO Admin(adminId, initials)
VALUES (3, 'KSJ');
INSERT INTO Admin(adminId, initials)
VALUES (4, 'LBB');