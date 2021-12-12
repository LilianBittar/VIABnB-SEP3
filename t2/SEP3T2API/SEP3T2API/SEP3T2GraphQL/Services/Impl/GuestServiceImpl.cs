using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;
using SEP3T2GraphQL.Services.Validation.GuestValidation;
using SEP3T2GraphQL.Services.Validation.GuestValidation.Impl;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class GuestServiceImpl : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IGuestValidation _guestValidation;
        private readonly CreateGuestValidator _createGuestValidator;

        public GuestServiceImpl(IGuestRepository guestRepository, CreateGuestValidator createGuestValidator)
        {
            _guestRepository = guestRepository;
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

        public async Task<Guest> GetGuestByStudentNumberAsync(int studentNumber)
        {
            if (_guestValidation.IsValidStudentNumber(studentNumber))
            {
                try
                {
                    return await _guestRepository.GetGuestByStudentNumberAsync(studentNumber);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            throw new ArgumentException("No user with such student number");
        }

        public async Task<Guest> ValidateGuestAsync(string email, string password)
        {
            var returnedGuest = await GetGuestByEmailAsync(email);
            if (returnedGuest == null) throw new KeyNotFoundException("user not found");
            if (returnedGuest.Password != password)
            {
                throw new ArgumentException("the password is not matching");
            }
            else return returnedGuest;
        }
    }
    
}