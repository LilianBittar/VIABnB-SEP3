using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Impl;

namespace SEP3T2GraphQL.Services.Validation
{
    /// <summary>
    /// Utility class for validating a Guest
    /// </summary>
    public  class CreateGuestValidator
    {
        private IGuestRepository _guestRepository;
        private IHostRepository _hostRepository;

        public CreateGuestValidator(IGuestRepository guestRepository, IHostRepository hostRepository)
        {
            _guestRepository = guestRepository;
            _hostRepository = hostRepository;
        }

        /// <summary>
        /// Validates a guest based on data annotations, email,
        /// student number(viaId), if the guest has been approved as host, if guest's via id is not used by other guest and
        /// if guest is an host. 
        /// </summary>
        /// <param name="guest">the guest to be validated</param>
        /// <exception cref="ArgumentException">if guest has invalid email, i.e. no contains no @ or ends with dot</exception>
        /// <exception cref="ArgumentException">if guest's fields doesn't satisfy to models data annotations</exception>
        /// <exception cref="ArgumentException">if guest's student number is invalid, i.e. not 6 digits or negative number</exception>
        /// <exception cref="ArgumentException">if guest is not approved as host before becoming guest</exception>
        /// <exception cref="ArgumentException">If an guest with same student number already exists</exception>
        /// <exception cref="KeyNotFoundException">If no existing host could be found</exception>

        public  async Task ValidateGuest(Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentException("Guest cannot be null"); 
            }
            await ValidateGuestIsExistingHost(guest);
            ValidateHostApproval(guest);
            ValidateStudentNumber(guest);
            await ValidateViaIdUnused(guest);
            ValidateEmail(guest);
            ValidateDataAnnotations(guest);

        }

        /// <summary>
        /// Validates an email of an guest. Checks if the emails contains @ or if the emails ends with a dot.
        /// </summary>
        /// <param name="guest">Guest who's email is to be validated </param>
        /// <exception cref="ArgumentException">Email does not contain @</exception>
        /// <exception cref="ArgumentException">Email ends with a dot</exception>
        /// <exception cref="ArgumentException">Email is null</exception>
        private  void ValidateEmail(Guest guest)
        {
            if (guest.Email == null)
            {
                throw new ArgumentException("Email cannot be null"); 
            }
            
            if (guest.Email.Trim().EndsWith("."))
            {
                throw new ArgumentException("Invalid email");
            }

            if (!guest.Email.Contains("."))
            {
                throw new ArgumentException("Invalid email");
            }

            try
            {
                var mailAddress = new MailAddress(guest.Email);
            }
            catch
            {
                throw new ArgumentException("Invalid email");
            }
        }

        /// <summary>
        /// Validates the student number of the guest.
        /// </summary>
        /// <param name="guest">The guest who's student number is to be validated</param>
        /// <exception cref="ArgumentException">student number is negative</exception>
        /// <exception cref="ArgumentException">student number is not 6 digits</exception>
        private  void ValidateStudentNumber(Guest guest)
        {
            var studentNumberAsString = guest.ViaId.ToString();
            if (studentNumberAsString.Length != 6)
            {
                throw new ArgumentException("Invalid student number");
            }

            if (guest.ViaId < 0)
            {
                throw new ArgumentException("Invalid student number");
            }
        }

        /// <summary>
        /// Validates if the fields of the guest satisfy the data annotations
        /// </summary>
        /// <param name="guest">the guest which is to be validated</param>
        /// <exception cref="ArgumentException">if field does not satisfy a data annotation</exception>
        private void ValidateDataAnnotations(Guest guest)
        {
            var context = new ValidationContext(guest, null, null);
            List<ValidationResult> validationResults = new();
            bool isValidGuest = Validator.TryValidateObject(guest, context, validationResults, true);
            if (!isValidGuest)
            {
                throw new ArgumentException(validationResults[0].ErrorMessage);
            }
        }

        /// <summary>
        /// Validates if the guest has been approved as a host before becoming a guest
        /// </summary>
        /// <param name="guest">the guest which host approval is to be validated</param>
        /// <exception cref="ArgumentException">if the guest has not been approved as a host before becoming guest</exception>
        private void ValidateHostApproval(Guest guest)
        {
            if (!guest.IsApprovedHost)
            {
                throw new ArgumentException("Must be approved as host before becoming guest");
            }
        }
        /// <summary>
        /// Validates if the Guest is registered as host before becoming guest. 
        /// </summary>
        /// <param name="guest">Guest who is being validated</param>
        /// <exception cref="KeyNotFoundException">If no existing host could be found</exception>
        private async Task ValidateGuestIsExistingHost(Guest guest)
        {
            try
            {
                Host existingHost = await _hostRepository.GetHostByIdAsync(guest.Id);
                if (existingHost == null)
                {
                    throw new KeyNotFoundException("Host does not exist"); 
                }
            }
            catch (NullReferenceException e)
            {
                throw new KeyNotFoundException("Host does not exist"); 
            }
        }
        /// <summary>
        /// Validates if any other guests has already used the student number provided during registration. 
        /// </summary>
        /// <param name="guest">Guest who is being validated</param>
        /// <exception cref="ArgumentException">If an guest with same student number already exists</exception>
        private async Task ValidateViaIdUnused(Guest guest)
        {
            var allGuests = await _guestRepository.GetAllGuestsAsync();
            if (allGuests.Any(g => g.ViaId == guest.ViaId))
            {
                throw new ArgumentException("Guest with provided student number already exists");
            }   
        }
        
    }
}