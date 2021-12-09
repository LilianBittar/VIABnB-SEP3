using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Impl;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;


namespace UnitTests
{
    public class RegisterHostTest
    {
        private Host host = new Host();
        private IHostService HostService;
        private Mock<IHostRepository> HostRepository;
        private Mock<IUserService> _userService;


        [SetUp]
        public void SetUp()
        {
            HostRepository = new Mock<IHostRepository>();
            _userService = new Mock<IUserService>();
            HostService = new HostServiceImpl(HostRepository.Object,new HostValidationImpl(_userService.Object));
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
                Cpr = "123456-1234",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            Assert.DoesNotThrow(() => HostService.RegisterHostAsync(host));
        }
        
        [TestCase("email@gmailcom")]
        [TestCase("emailgmailcom")]
        [TestCase("email@gmail.com.")]
        [TestCase(null)]
        public void IsValidHost_InvalidEmail_Throws(string email)
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = "Bobsen",
                Email = email,
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            Assert.ThrowsAsync<FormatException>(() => HostService.RegisterHostAsync(host));
        }
        
        [Test]
        public void IsValidHost_EmailAlreadyExists_Throws()
        {
            //arange
            User user = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = "Bobsen",
                Email = "bob@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            
            User user2 = new Host()
            {
                Id = 5,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "bob@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            
            _userService
                .Setup<User>(x => x.GetUserByEmailAsync(host.Email).Result)
                .Returns(user2);

            //act and assert
            Assert.ThrowsAsync<ArgumentException>(() => HostService.RegisterHostAsync(host));
        }
        
        [TestCase("Kasper34")]
        [TestCase("!%/)(")]
        [TestCase(null)]
        public void IsValidHost_InvalidFirstname_Throws(String firstname)
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = firstname,
                LastName = "Bobsen",
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            TestCreateThrowsArgumentExceptionAsync(host);
        }
        
        [TestCase("B00bsen")]
        [TestCase("!%/)(")]
        [TestCase(null)]
        public void IsValidHost_InvalidLastname_Throws(string lastname)
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = lastname,
                Email = "email@gmail.com",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };

            //act and assert
            TestCreateThrowsArgumentExceptionAsync(host);
        }
        
        [TestCase("121232132131233")]
        [TestCase("hedsafasdfasdfsdaf")]
        [TestCase("AKSHASKHGas")]
        [TestCase("Aa1")]
        [TestCase(null)]
        [TestCase("1")]
        [TestCase("12345")]
        [TestCase("1234567")]
        public void IsValidHost_InvalidPassword_Throws(string password)
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
            TestCreateThrowsArgumentExceptionAsync(host);
        }
        
        [TestCase("345345a")]
        [TestCase(null)]
        [TestCase("23423434#")]
        public void IsValidHost_InvalidPhoneNumber_Throws(string phoneNumber)
        {
            //arange
            host = new Host()
            {
                Id = 0,
                FirstName = "Kasper",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                Cpr = "123456-1243",
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmaeddig123",
                PhoneNumber = phoneNumber,
                ProfileImageUrl = null
            };

            //act and assert
            TestCreateThrowsArgumentExceptionAsync(host);
        }

      


        [TestCase("hej@dig.dk")]
        [TestCase("hej123@diggg.dk")]
        [TestCase("he123!?j@dig.dk")]
        [TestCase("h23ej@dig.com")]
        public void IsValidEmail_ExpectedValues_DoesNotThrow(string email)
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = email,
                HostReviews = null,
                IsApprovedHost = false,
                Password = "Hejmeddig123",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.DoesNotThrow(() => HostService.RegisterHostAsync(host));

        }

        
        [TestCase("Aa345678")]
        [TestCase("Aa3456789")]
        [TestCase("Aa345679123456789")]
        public void IsValidPassword_length8orHigher_DoesNotThrow(string password)
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
                Password = password,
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.DoesNotThrow(() => HostService.RegisterHostAsync(host));
        }

        
        
        [TestCase("123456-1234")]
        [TestCase("1234561234")]
        public void IsValidCpr_CorrectLengthWithAndWithoutDash_DoesNotThrow(string cpr)
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                Cpr = cpr,
                HostReviews = null,
                IsApprovedHost = false,
                Password = "HejMedDig12345",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            Assert.DoesNotThrow(() => HostService.RegisterHostAsync(host));
        }
        
        
        [TestCase("12345612345")]
        [TestCase("123456-123")]
        [TestCase("123456-123")]
        [TestCase("12ab56-1234")]
        public void IsValidCpr_IncorrectLengthWithAndWithoutDash_Throws(string cpr)
        {
            //arrange
            host = new Host()
            {
                Id = 0,
                FirstName = "Bob",
                LastName = "Bobsen",
                Email = "email@gmail.com",
                Cpr = cpr,
                HostReviews = null,
                IsApprovedHost = false,
                Password = "HejMedDig12345",
                PhoneNumber = "12345678",
                ProfileImageUrl = null
            };
            //act and assert
            TestCreateThrowsArgumentExceptionAsync(host);
        }
        private void TestCreateThrowsArgumentExceptionAsync(Host _host)
        {
            Assert.ThrowsAsync<ArgumentException>(() => HostService.RegisterHostAsync(_host));
        }
    }
}