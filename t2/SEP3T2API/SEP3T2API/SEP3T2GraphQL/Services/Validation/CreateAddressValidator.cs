using System;
using System.Linq;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation
{
    /// <summary>
    /// Utility Class that validates if the Create Address event can occur. 
    /// </summary>
    public class CreateAddressValidator
    {

        /// <summary>
        ///  Method to validate if an address can be created. 
        /// </summary>
        /// <remarks>
        /// This method will return void if validation succeeds. If validation fails, then an <c>ArgumentException</c> will be thrown. 
        /// </remarks>
        /// <param name="address"></param>
        /// <exception cref="ArgumentException">If  <c>StreetName</c>, <c>StreetNumber</c>, <c>HouseNumber</c> or <c>City</c>, of <c>address</c> is null or empty </exception>
        /// <exception cref="ArgumentException">If <c>StreetName</c> of <c>address</c> contains any chars that is not letter</exception>
        public void Validate(Address address)
        {
            if (address == null)
            {
                throw new ArgumentException("Address is required");
            }

            ValidateFieldsNotEmptyOrNull(address);
            ValidateStreetNameIsLettersOnly(address);
        }

        /// <summary>
        /// Validates if the <c>StreetName</c>, <c>StreetNumber</c>, <c>HouseNumber</c> or <c>City</c>, of <c>address</c> is either null or empty. 
        /// </summary>
        /// <remarks>
        /// This method will return void if validation succeeds. If validation fails, then an <c>ArgumentException</c> will be thrown. 
        /// </remarks>
        /// <param name="address">The address that is being validated</param>
        /// <exception cref="ArgumentException">If  <c>StreetName</c>, <c>StreetNumber</c> or <c>City</c>, of <c>address</c> is null or empty </exception>
        private void ValidateFieldsNotEmptyOrNull(Address address)
        {
            if (string.IsNullOrEmpty(address.StreetName) || string.IsNullOrWhiteSpace(address.StreetName))
            {
                throw new ArgumentException("StreetName cannot be null or empty");
            }

            if (string.IsNullOrEmpty(address.StreetNumber) || string.IsNullOrWhiteSpace(address.StreetNumber))
            {
                throw new ArgumentException("StreetNumber cannot be null or empty");
            }
            

            if (address.City == null)
            {
                throw new ArgumentException("City cannot be null");
            }
        }

        /// <summary>
        /// Validates if the <c>StreetName</c> of <c>address</c> contains letters only. 
        /// </summary>
        /// <remarks>
        /// This method will return void if validation succeeds. If validation fails, then an <c>ArgumentException</c> will be thrown. 
        /// </remarks>
        /// <param name="address">the address that is being validated</param>
        /// <exception cref="ArgumentException">If <c>StreetName</c> of <c>address</c> contains any chars that is not letter</exception>
        private void ValidateStreetNameIsLettersOnly(Address address)
        {
            if (address.StreetName.Any(c => !char.IsLetter(c)))
            {
                throw new ArgumentException("StreetName must only contain letters");
            }
        }
    }
}