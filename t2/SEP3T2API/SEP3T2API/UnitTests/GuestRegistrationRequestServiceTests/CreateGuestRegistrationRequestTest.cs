// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Moq;
// using NUnit.Framework;
// using SEP3T2GraphQL.Models;
// using SEP3T2GraphQL.Repositories;
// using SEP3T2GraphQL.Services;
// using SEP3T2GraphQL.Services.Impl;
//
// namespace UnitTests.GuestRegistrationRequestServiceTests
// {
//     [TestFixture]
//     public class CreateGuestRegistrationRequestTest
//     {
//         private IGuestRegistrationRequestService _guestRegistrationRequestService;
//
//
//         [SetUp]
//         public void SetUp()
//         {
//             // Mock setup
//             var repository = new Mock<IGuestRegistrationRequestRepository>();
//             Host host = new Host()
//             {
//                 Email = "test@test.com", FirstName = "test0", LastName = "test0", Id = 42, Password = "test",
//                 PhoneNumber = "88888888", IsApprovedHost = true
//             };
//             repository
//                 .Setup<IEnumerable<GuestRegistrationRequest>>(x => x.GetAllGuestRegistrationRequestsAsync().Result)
//                 .Returns(new List<GuestRegistrationRequest>()
//                 {
//                     new GuestRegistrationRequest()
//                     {
//                         Id = 42, Host = host, Status = RequestStatus.NotAnswered, StudentNumber = 424242,
//                         StudentIdImage = "TEST"
//                     }
//                 });
//             _guestRegistrationRequestService = new GuestRegistrationRequestServiceImpl(repository.Object);
//         }
//
//         [Test]
//         public void CreateRequest_RequestIsValid_DoesNotThrow()
//         {
//             Host host = new Host()
//             {
//                 Email = "test@test.com", FirstName = "test", LastName = "test", Id = 1, Password = "test",
//                 PhoneNumber = "88888888", IsApprovedHost = true
//             };
//
//             GuestRegistrationRequest request = new GuestRegistrationRequest()
//             {
//                 Id = 1, Host = host, Status = RequestStatus.NotAnswered, StudentNumber = 293886, StudentIdImage = "TEST"
//             };
//
//             Assert.DoesNotThrowAsync(async () =>
//                 await _guestRegistrationRequestService.CreateGuestRegistrationRequestAsync(request));
//         }
//
//         [Test]
//         public void CreateRequest_RequestIsNull_ThrowsArgumentExceptions()
//         {
//             GuestRegistrationRequest request = null;
//             Assert.ThrowsAsync<ArgumentException>(async () => await
//                 _guestRegistrationRequestService.CreateGuestRegistrationRequestAsync(request));
//         }
//
//         [Test]
//         public void CreateRequest_HostNotApproved_ThrowsArgumentException()
//         {
//             Host host = new Host()
//             {
//                 Email = "test@test.com", FirstName = "test", LastName = "test", Id = 1, Password = "test",
//                 PhoneNumber = "88888888", IsApprovedHost = false
//             };
//
//             GuestRegistrationRequest request = new GuestRegistrationRequest()
//             {
//                 Id = 1, Host = host, Status = RequestStatus.NotAnswered, StudentNumber = 293886, StudentIdImage = "TEST"
//             };
//             Assert.ThrowsAsync<ArgumentException>(async () =>
//                 await _guestRegistrationRequestService.CreateGuestRegistrationRequestAsync(request));
//         }
//
//         [Test]
//         public void CreateRequest_StudentIdImageIsNull_ThrowsArgumentExceptions()
//         {
//             Host host = new Host()
//             {
//                 Email = "test@test.com", FirstName = "test", LastName = "test", Id = 1, Password = "test",
//                 PhoneNumber = "88888888", IsApprovedHost = true
//             };
//
//             GuestRegistrationRequest request = new GuestRegistrationRequest()
//             {
//                 Id = 1, Host = host, Status = RequestStatus.NotAnswered, StudentNumber = 293886, StudentIdImage = null
//             };
//
//             Assert.ThrowsAsync<ArgumentException>(async () =>
//                 await _guestRegistrationRequestService.CreateGuestRegistrationRequestAsync(request));
//         }
//
//         [Test]
//         [TestCase(0)]
//         [TestCase(-1)]
//         [TestCase(-100)]
//         [TestCase(-29388)]
//         public void CreateRequest_StudentNumberIsZeroOrLess_ThrowsArgumentException(int studentNumber)
//         {
//             Host host = new Host()
//             {
//                 Email = "test@test.com", FirstName = "test", LastName = "test", Id = 1, Password = "test",
//                 PhoneNumber = "88888888", IsApprovedHost = true
//             };
//
//             GuestRegistrationRequest request = new GuestRegistrationRequest()
//             {
//                 Id = 1, Host = host, Status = RequestStatus.NotAnswered, StudentNumber = studentNumber,
//                 StudentIdImage = "TEST"
//             };
//
//             Assert.ThrowsAsync<ArgumentException>(async () =>
//                 await _guestRegistrationRequestService.CreateGuestRegistrationRequestAsync(request));
//         }
//
//
//         [Test]
//         [TestCase(29388)]
//         [TestCase(2938866)]
//         [TestCase(2)]
//         [TestCase(293886632)]
//         public void CreateRequest_StudentNumberLengthIsNotSixCharactersAsString_ThrowsArgumentException(
//             int studentNumber)
//         {
//             Host host = new Host()
//             {
//                 Email = "test@test.com", FirstName = "test", LastName = "test", Id = 1, Password = "test",
//                 PhoneNumber = "88888888", IsApprovedHost = true
//             };
//
//             GuestRegistrationRequest request = new GuestRegistrationRequest()
//             {
//                 Id = 1, Host = host, Status = RequestStatus.NotAnswered, StudentNumber = studentNumber,
//                 StudentIdImage = "TEST"
//             };
//
//             Assert.ThrowsAsync<ArgumentException>(async () =>
//                 await _guestRegistrationRequestService.CreateGuestRegistrationRequestAsync(request));
//         }
//
//         [Test]
//         public void CreateRequest_StudentNumberAlreadyUsed_ThrowsArgumentException()
//         {
//             Host host = new Host()
//             {
//                 Email = "test@test.com", FirstName = "test", LastName = "test", Id = 1, Password = "test",
//                 PhoneNumber = "88888888", IsApprovedHost = true
//             };
//
//             GuestRegistrationRequest request = new GuestRegistrationRequest()
//             {
//                 Id = 1, Host = host, Status = RequestStatus.NotAnswered, StudentNumber = 424242,
//                 StudentIdImage = "TEST"
//             };
//
//             Assert.ThrowsAsync<ArgumentException>(async () =>
//                 await _guestRegistrationRequestService.CreateGuestRegistrationRequestAsync(request));
//         }
//     }
// }