using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation;

namespace UnitTests
{
    [TestFixture]
    public class GuestValidatorTest
    {
        [Test]
        [TestCase("testtest.com")]
        [TestCase("test@testcom")]
        [TestCase("test@testcom.")]
        [TestCase("testtestcom")]
        public void ValidateGuest_InvalidEmail_ThrowsArgumentException(string email)
        {
            //Test caught bug where email was valid even if it did not contain a dot
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = email, Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 303030, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            Assert.Throws<ArgumentException>(() => GuestValidator.ValidateGuest(guest)); 
        }

        [Test]
        public void ValidateGuest_ValidGuest_DoesNotThrow()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 303030, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            Assert.DoesNotThrow(()=>GuestValidator.ValidateGuest(guest));
        }

        [Test]
        [TestCase(29388)]
        [TestCase(2938866)]
        [TestCase(2)]
        [TestCase(299999999)]
        [TestCase(-29388)]
        public void ValidateGuest_InvalidStudentNumber_ThrowsArgumentException(int studentNumber)
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = studentNumber, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            Assert.Throws<ArgumentException>(() => GuestValidator.ValidateGuest(guest));
        }

        [Test]
        public void ValidateGuest_GuestIsNotApprovedHost_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = false, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            Assert.Throws<ArgumentException>(()=>GuestValidator.ValidateGuest(guest));
        }
        
        [Test]
        public void ValidateGuest_NullFirstName_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = null,
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            Assert.Throws<ArgumentException>(()=>GuestValidator.ValidateGuest(guest));
        }
        
        [Test]
        public void ValidateGuest_NullLastName_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = null,
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            Assert.Throws<ArgumentException>(()=>GuestValidator.ValidateGuest(guest));
        }

        [Test]
        public void ValidateGuest_NullPhoneNumber_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = null, ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            Assert.Throws<ArgumentException>(()=>GuestValidator.ValidateGuest(guest));
        }
        
        [Test]
        public void ValidateGuest_NullEmail_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = null, Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            Assert.Throws<ArgumentException>(()=>GuestValidator.ValidateGuest(guest));
        }
        
        [Test]
        public void ValidateGuest_NullPassword_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = "222222-2222", Email = "test@test.com", Password = null, FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            Assert.Throws<ArgumentException>(()=>GuestValidator.ValidateGuest(guest));
        }
        
        [Test]
        public void ValidateGuest_NullCpr_ThrowsArgumentException()
        {
            Guest guest = new()
            {
                Id = 4, Cpr = null, Email = "test@test.com", Password = "test123123", FirstName = "test",
                GuestReviews = new List<GuestReview>(), HostReviews = new List<HostReview>(), LastName = "test",
                PhoneNumber = "+4588888888", ViaId = 293886, IsApprovedHost = true, IsApprovedGuest = false,
                ProfileImageUrl = null
            };
            
            Assert.Throws<ArgumentException>(()=>GuestValidator.ValidateGuest(guest));
        }
    }
}