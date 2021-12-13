DROP SCHEMA IF EXISTS viabnb CASCADE;
CREATE SCHEMA viabnb;
SET SCHEMA 'viabnb';

CREATE TABLE IF NOT EXISTS _User
(
    userId        serial,
    email         VARCHAR,
    password      VARCHAR,
    fName         VARCHAR,
    lName         VARCHAR,
    phoneNumber   VARCHAR,
    personalImage VARCHAR,
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
    hostId     serial,
    cprNumber  VARCHAR,
    isApproved BOOLEAN,
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
    createDate     DATE,
    PRIMARY KEY (rentRequestId),
    FOREIGN KEY (hostId) REFERENCES Host (hostid) ON DELETE CASCADE ,
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceid) ON DELETE CASCADE ,
    foreign key (guestId) references Guest (guestId)
);
CREATE TABLE IF NOT EXISTS Rule
(
    ruleDescription VARCHAR,
    residenceId     INT,
    PRIMARY KEY (residenceId, ruleDescription),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceId) ON DELETE CASCADE
);


CREATE TABLE IF NOT EXISTS GuestReview
(
    guestRating     DECIMAL,
    guestReviewText VARCHAR,
    hostId          INT,
    guestId         INT,
    createdDate     DATE,
    PRIMARY KEY (hostId, guestId),
    FOREIGN KEY (hostId) REFERENCES Host (hostid),
    FOREIGN KEY (guestId) REFERENCES Guest (guestId) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS HostReview
(
    hostRating     DECIMAL,
    hostReviewText VARCHAR,
    hostId         INT,
    guestId        INT,
    createdDate    DATE,
    PRIMARY KEY (hostId, guestId),
    FOREIGN KEY (hostId) REFERENCES Host (hostid),
    FOREIGN KEY (guestId) REFERENCES Guest (guestId) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS ResidenceReview
(
    residenceRating     DECIMAL,
    residenceReviewText VARCHAR,
    residenceId         INT,
    guestId             INT,
    createdDate         DATE,
    PRIMARY KEY (residenceId, guestId),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceId) ON DELETE CASCADE ,
    FOREIGN KEY (guestId) REFERENCES Guest (guestId) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS ResidenceFacility
(
    facilityId  INT,
    residenceId INT,
    PRIMARY KEY (facilityId, residenceId),
    FOREIGN KEY (facilityId) REFERENCES Facility (facilityId),
    FOREIGN KEY (residenceId) REFERENCES Residence (residenceId) ON DELETE CASCADE
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

CREATE TABLE IF NOT EXISTS message
(
    senderId       INT,
    receiverId     INT,
    messageContent varchar,
    timeSent       timestamp,

    PRIMARY KEY (senderId, receiverId, timeSent),
    FOREIGN KEY (senderId) references _user (userid) ON DELETE CASCADE ,
    FOREIGN KEY (receiverId) references _user(userid) ON DELETE CASCADE
);

--The system's admins
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('291597@via.dk', 'Aa123456', 'Kutaiba', 'Kashmar', '11111111', 'image');
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('293886@via.dk', 'Aa123456', 'Michael', 'Bui', '22222222', 'image');
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('304218@via.dk', 'Aa123456', 'Kasper', 'Jensen', '33333333', 'image');
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('293336@via.dk', 'Aa123456', 'Lilian', 'Bittar', '44444444', 'image');

INSERT INTO Admin(initials)
VALUES ('KNK');
INSERT INTO Admin(initials)
VALUES ('MTB');
INSERT INTO Admin(initials)
VALUES ('KSJ');
INSERT INTO Admin(initials)
VALUES ('LBB');

--Other users
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('john@gmail.com', 'Aa123456', 'John', 'Johnson', '55555555', 'image');
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('bob@gmail.com', 'Aa123456', 'Bob', 'Bobsen', '66666666', 'image');
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('sara@hotmail.com', 'Aa123456', 'Sara', 'Sarsen', '77777777', 'image');
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('alice@outlook.com', 'Aa123456', 'Alice', 'Aliceson', '8888888', 'image');
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('shrek@ogre.org', 'Aa123456', 'Shrek', 'Shrekson', '99999999', 'image');
INSERT INTO _User(email, password, fName, lName, phoneNumber, personalImage)
VALUES ('mario@nintendo.org', 'Aa123456', 'Mario', 'Mario', '10000000', 'image');

--Host
INSERT INTO Host(hostid, cprNumber, isApproved)
VALUES (5, '1111111111', true);
INSERT INTO Host(hostid, cprNumber, isApproved)
VALUES (6, '2222222222', true);
INSERT INTO Host(hostid, cprNumber, isApproved)
VALUES (7, '3333333333', true);
INSERT INTO Host(hostid, cprNumber, isApproved)
VALUES (8, '444444444', true);
INSERT INTO Host(hostid, cprNumber, isApproved)
VALUES (9, '5555555555', true);
INSERT INTO Host(hostid, cprNumber, isApproved)
VALUES (10, '6666666666', true);

--Guest

INSERT INTO Guest(guestid, viaId, isApprovedGuest)
VALUES (5, 111111, true);
INSERT INTO Guest(guestid, viaId, isApprovedGuest)
VALUES (6, 222222, true);
INSERT INTO Guest(guestid, viaId, isApprovedGuest)
VALUES (7, 333333, true);
INSERT INTO Guest(guestid, viaId, isApprovedGuest)
VALUES (8, 444444, true);
INSERT INTO Guest(guestid, viaId, isApprovedGuest)
VALUES (9, 555555, true);
INSERT INTO Guest(guestid, viaId, isApprovedGuest)
VALUES (10, 666666, true);

--City

INSERT INTO City(cityName, zipcode)
VALUES ('Horsens', 8700);
INSERT INTO City(cityName, zipcode)
VALUES ('Århus Ø', 8000);
INSERT INTO City(cityName, zipcode)
VALUES ('København N', 2200);
INSERT INTO City(cityName, zipcode)
VALUES ('Odense S', 5000);

--Address

INSERT INTO Address(streetName, streetNumber, houseNumber, cityId)
VALUES ('Strandvejen', '1', '1, st', 1);
INSERT INTO Address(streetName, streetNumber, houseNumber, cityId)
VALUES ('Åboulevarden', '5', '5, 3 sal th', 1);
INSERT INTO Address(streetName, streetNumber, houseNumber, cityId)
VALUES ('Åboulevarden', '8', '6, st', 2);
INSERT INTO Address(streetName, streetNumber, houseNumber, cityId)
VALUES ('Kollegievænget', '3', '2, sal tv', 1);
INSERT INTO Address(streetName, streetNumber, houseNumber, cityId)
VALUES ('Odensevej', '10', '16D', 3);
INSERT INTO Address(streetName, streetNumber, houseNumber, cityId)
VALUES ('Århusvej', '2', '1A', 4);
INSERT INTO Address(streetName, streetNumber, houseNumber, cityId)
VALUES ('Københavnsvej', '6', '1, st', 3);
INSERT INTO Address(streetName, streetNumber, houseNumber, cityId)
VALUES ('Horsensvej', '5', '1F', 2);


--Residence

INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (1, 'House', '3 bedroom house', true, 1500, '2022-12-04', '2023-12-01', 'Image', 10, 6);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (2, 'Apartment', '1 bedroom apartment', true, 200, '2022-12-04', '2023-12-01', 'Image', 1, 6);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (3, 'Sofa', 'Comfy sofa', true, 50, '2022-12-04', '2023-12-01', 'Image', 1, 5);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (4, 'House', '10 bedroom house', true, 500, '2022-12-04', '2023-12-01', 'Image', 15, 8);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (5, 'House', '1 bedroom house', true, 500, '2022-12-04', '2023-12-01', 'Image', 2, 8);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (6, 'Bed', 'Double bed', true, 500, '2022-12-04', '2023-12-01', 'Image', 2, 9);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (7, 'Matres', 'Air matres', true, 500, '2022-12-04', '2023-12-01', 'Image', 1, 10);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (8, 'Apartment', '5 bedroom apartment', true, 500, '2022-12-04', '2023-12-01', 'Image', 6, 7);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (2, 'Room', 'Guest room', true, 500, '2022-12-04', '2023-12-01', 'Image', 3, 7);
INSERT INTO Residence(addressId, type, description, isAvailable, pricePrNight, availableFrom, availableTo, imageUrl,
                      maxNumberOfGuests, hostId)
VALUES (5, 'Summer house', '2 bedroom summer house', true, 500, '2022-12-04', '2023-12-01', 'Image', 4, 9);


--Facility

INSERT INTO Facility(name)
VALUES ('Wifi');
INSERT INTO Facility(name)
VALUES ('Free parking');
INSERT INTO Facility(name)
VALUES ('Refrigerator');
INSERT INTO Facility(name)
VALUES ('Kitchen');
INSERT INTO Facility(name)
VALUES ('Backyard');
INSERT INTO Facility(name)
VALUES ('Microwave');
INSERT INTO Facility(name)
VALUES ('Bed linens');
INSERT INTO Facility(name)
VALUES ('Extra pillows and blankets');
INSERT INTO Facility(name)
VALUES ('Heating');
INSERT INTO Facility(name)
VALUES ('Smoke alarm');
INSERT INTO Facility(name)
VALUES ('Fire extinguisher');
INSERT INTO Facility(name)
VALUES ('First aid kit');
INSERT INTO Facility(name)
VALUES ('Dishes and silverware');
INSERT INTO Facility(name)
VALUES ('Oven');
INSERT INTO Facility(name)
VALUES ('TV');
INSERT INTO Facility(name)
VALUES ('WasherWasher');
INSERT INTO Facility(name)
VALUES ('Air conditioning');
INSERT INTO Facility(name)
VALUES ('Hair dryer');
INSERT INTO Facility(name)
VALUES ('ShampooShampoo');