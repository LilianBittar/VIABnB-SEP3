using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation
{
    public static class GuestValidator
    {
        /// <summary>
        /// Utility class for validating a guest based on data annotations, email,
        /// student number(viaId) and if the guest has been approved as host. 
        /// </summary>
        /// <param name="guest">the guest to be validated</param>
        /// <exception cref="ArgumentException">if guest has invalid email, i.e. no contains no @ or ends with dot</exception>
        /// <exception cref="ArgumentException">if guest's fields doesn't satisfy to models data annotations</exception>
        /// <exception cref="ArgumentException">if guest's student number is invalid, i.e. not 6 digits or negative number</exception>
        /// <exception cref="ArgumentException">if guest is not approved as host before becoming guest</exception>
        public static void ValidateGuest(Guest guest)
        {
            ValidateHostApproval(guest);
            ValidateStudentNumber(guest);
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
        private static void ValidateEmail(Guest guest)
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
        private static void ValidateStudentNumber(Guest guest)
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
        private static void ValidateDataAnnotations(Guest guest)
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
        private static void ValidateHostApproval(Guest guest)
        {
            if (!guest.IsApprovedHost)
            {
                throw new ArgumentException("Must be approved as host before becoming guest");
            }
        }
    }
}