using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Impl;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation.GuestValidation;
using SEP3T2GraphQL.Services.Validation.GuestValidation.Impl;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;

namespace UnitTests
{
    public class GetGuestByStudentNumber
    {
        private IGuestService guestService;
        private IGuestRepository GuestRepository;
        private IGuestValidation GuestValidation;
        private IHostService HostService;
        private Guest guest;
        private IHostRepository HostRepository;
        private IHostValidation HostValidation;
        private Mock<IGuestRepository> _guestRepositoryMock = new Mock<IGuestRepository>();

        [SetUp]

        public void SetUp()
        {
            GuestValidation = new GuestValidationImpl();
            GuestRepository = new GuestRepository();
            HostValidation = new HostValidationImpl();
            HostRepository = new HostRepositoryImpl();
            HostService = new HostServiceImpl(HostRepository);
            guestService = new GuestServiceImpl(_guestRepositoryMock.Object, HostService);
             guest = new Guest()
            {
                Id = 1,
                Cpr = "1111111111",
                Email = "catman@cat.dk",
                FirstName = "cat",
                LastName = "man",
                GuestReviews = new List<GuestReview>(),
                HostReviews = new List<HostReview>(),
                IsApprovedGuest = true,
                IsApprovedHost = true,
                Password = "Cat123"
            };
        }
        
        [Test]
        
        public void GetGuestByStudentNumberWithValidStudentNumberDoesNotThrowException()
        {
            int studentNumber = 111111;
            _guestRepositoryMock.Setup<Guest>(x => x.GetGuestByStudentNumber(111111).Result)
                .Returns(guest);
            Assert.DoesNotThrowAsync(()=>guestService.GetGuestByStudentNumber(studentNumber));
           
        }
        
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(12134)]
        [TestCase(1213422)]
        
        public void GetGuestByStudentNumberWithInValidStudentNumberThrowsArgumentException(int studentNumber)
        {

            _guestRepositoryMock.Setup<Guest>(x => x.GetGuestByStudentNumber(studentNumber).Result)
                .Returns(guest);
            Assert.ThrowsAsync<ArgumentException>(async ()=> await guestService.GetGuestByStudentNumber(studentNumber));
           
        }
        
    }
    
}