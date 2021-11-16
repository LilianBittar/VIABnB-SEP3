﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;


namespace UnitTests
{
    public class RegisterHostTest
    {
        private Host host = new Host();
        private IHostValidation _hostValidationImpl;

        [SetUp]
        public void SetUp()
        {
            _hostValidationImpl = new HostValidationImpl();

        }

        [Test]
        public void IsValidHost_ExpectedValues_DoesNotThrow()
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            Assert.DoesNotThrow(() => _hostValidationImpl.IsValidHost(host));
        }
        
        [Test]
        public void IsValidHost_InvalidEmail_Throws()
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = "Bobsen",
                Email = "email@gmailcom",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            Assert.Throws<FormatException>(() => _hostValidationImpl.IsValidHost(host));
        }
        
        [Test]
        public void IsValidHost_InvalidFirstname_Throws()
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasp0+er",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidHost(host));
        }
        
        [Test]
        public void IsValidHost_InvalidLastname_Throws()
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = "B00bsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidHost(host));
        }
        
        [Test]
        public void IsValidHost_InvalidPassword_Throws()
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidHost(host));
        }
        
        [Test]
        public void IsValidHost_InvalidPhoneNumber_Throws()
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "1234bob5678",
                ProfileImageUrl = null
            };

            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidHost(host));
        }

        [Test]
        public void IsValidFirstname_null_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = null,
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidFirstname(host.FirstName));
        }

        [Test]
        public void IsValidFirstname_containsNumbers_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "B0b",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidFirstname(host.FirstName));
        }

        [Test]
        public void IsValidLastname_null_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = null,
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidLastname(host.LastName));
        }

        [Test]
        public void IsValidLastname_containsNumbers_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "B0b",
                LastName = "B0bsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidLastname(host.LastName));
        }

        [Test]
        public void IsValidEmail_ExpectedValues_DoesNotThrow()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.DoesNotThrow(() => _hostValidationImpl.IsValidEmail(host.Email));

        }

        [Test]
        public void IsValidEmail_DoesNotContainDot_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmailcom",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<FormatException>(() => _hostValidationImpl.IsValidEmail(host.Email));
        }

        [Test]
        public void IsValidEmail_DoesNotContainAtSign_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "emailmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<FormatException>(() => _hostValidationImpl.IsValidEmail(host.Email));
        }

        [Test]
        public void IsValidEmail_null_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = null,
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<FormatException>(() => _hostValidationImpl.IsValidEmail(host.Email));
        }

        [Test]
        public void IsValidEmail_endsWithDot_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com.",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<FormatException>(() => _hostValidationImpl.IsValidEmail(host.Email));
        }

        [Test]
        public void IsValidPassword_null_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = null,
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidPassword(host.Password));
        }

        [Test]
        public void IsValidPassword_lengthLessThan8_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "12345Aa",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidPassword(host.Password));
        }

        [Test]
        public void IsValidPassword_ContainsNoLowerCaseLetter_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "ABCDEFGH1IJKL",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidPassword(host.Password));
        }

        [Test]
        public void IsValidPassword_ContainsNoUpperCaseLetter_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "abcdfefeffeff1",
                PhoneNumber = "123456781",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidPassword(host.Password));
        }

        [Test]
        public void IsValidPassword_ContainsNoNumber_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "abcdfefeffeffSDSD",
                PhoneNumber = "123456781",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidPassword(host.Password));
        }

        [Test]
        public void IsValidPhoneNumber_Null_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "HejMedDig12345",
                PhoneNumber = null,
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidPhoneNumber(host.PhoneNumber));
        }

        [Test]
        public void IsValidPhoneNumber_ContainsLetter_Throws()
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "HejMedDig12345",
                PhoneNumber = "1234bob567",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.Throws<ArgumentException>(() => _hostValidationImpl.IsValidPhoneNumber(host.PhoneNumber));
        }


    }
}
