using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;
using SEP3T2GraphQL.Services.Validation.GuestValidation;
using SEP3T2GraphQL.Services.Validation.GuestValidation.Impl;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class GuestServiceImpl : IGuestService
    {
        private IGuestRepository _guestRepository;
        private IHostService _hostService;
        private IGuestService _guestService;
        private IGuestValidation _guestValidation;
        private CreateGuestValidator _createGuestValidator;

        public GuestServiceImpl(IGuestRepository guestRepository, IHostService hostService, CreateGuestValidator createGuestValidator)
        {
            _guestRepository = guestRepository;
            _hostService = hostService;
            _createGuestValidator = createGuestValidator;
            _guestValidation = new GuestValidationImpl();
        }

        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            await _createGuestValidator.ValidateGuest(guest);
            guest.IsApprovedGuest = false;
            var newGuest = await _guestRepository.CreateGuestAsync(guest);
            if (newGuest == null)
            {
                throw new Exception("Could not create new guest..."); 
            }
            return newGuest;
        }

        public async Task<Guest> GetGuestByStudentNumber(int studentNumber)
        {
            if (_guestValidation.IsValidStudentNumber(studentNumber))
            {
                try
                {
                    Console.WriteLine($"{this} logging in...");
                    Console.WriteLine($"{this}: Was passed this arg: {JsonConvert.SerializeObject(studentNumber)}");
                    return await _guestRepository.GetGuestByStudentNumber(studentNumber);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            throw new ArgumentException("No user with such student number");
        }

        public async Task<Guest> ValidateGuestAsync(int studentNumber, string password)
        {
            var returnedGuest = await GetGuestByStudentNumber(studentNumber);
            if (returnedGuest == null) throw new KeyNotFoundException("user not found");
            if (returnedGuest.Password != password)
            {
                throw new ArgumentException("the password is not matching");
            }
            else return returnedGuest;
        }
    }
    
}