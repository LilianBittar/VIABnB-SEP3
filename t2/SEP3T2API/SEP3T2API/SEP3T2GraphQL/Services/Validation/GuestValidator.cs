using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation
{
    public static class GuestValidator
    {
        /// <summary>
        /// Utility class for validating a guest based on data annotations. 
        /// </summary>
        /// <param name="guest">the guest to be validated</param>
        /// <exception cref="ArgumentException">if guest is invalid</exception>
        public static void ValidateGuest(Guest guest)
        {
            var context = new ValidationContext(guest, null, null);
            List<ValidationResult> validationResults = new();
            bool isValidGuest = Validator.TryValidateObject(guest, context, validationResults, true);
            ValidateEmail(guest);
            if (!isValidGuest)
            {
                throw new ArgumentException(validationResults[0].ErrorMessage); 
            }
        }
        
        /// <summary>
        /// Validates an email of an guest. Checks if the emails contains @ or if the emails ends with a dot.
        /// </summary>
        /// <param name="guest">Guest who's email is to be validated </param>
        /// <exception cref="ArgumentException">Email does not contain @</exception>
        /// <exception cref="ArgumentException">Email ends with a dot</exception>
        private static void ValidateEmail(Guest guest)
        {
            if (guest.Email.Trim().EndsWith("."))
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
        
    }
}