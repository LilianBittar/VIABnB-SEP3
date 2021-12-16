using System;
using System.Linq;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateCityValidator
    {
        /// <summary>
        /// Validates  if the create city event can occur. 
        /// </summary>
        /// <param name="city"></param>
        /// <remarks>
        /// This method will return void if validation succeeds. If validation fails, then an <c>ArgumentException</c> will be thrown. 
        /// </remarks>
        /// <exception cref="ArgumentException"> if <c>city</c> is null</exception>
        /// <exception cref="ArgumentException"> if the <c>CityName</c> of <c>city</c> is null or empty</exception>
        /// <exception cref="ArgumentException"> if the <c>CityName</c> of <c>city</c> is not 4 digits or if zipcode is negative</exception>
        public void ValidateCity(City city)
        {
            if (city == null)
            {
                throw new ArgumentException("City cannot be null");
            }

            ValidateCityNameNotNullOrEmpty(city);
            ValidateCityNameLettersOnly(city);
            ValidateZipCode(city);
        }

        /// <summary>
        /// Validates if the <c>CityName</c> of <c>city</c> is null or empty. 
        /// </summary>
        /// <param name="city">city that is being validated</param>
        /// <remarks>
        /// This method will return void if validation succeeds. If validation fails, then an <c>ArgumentException</c> will be thrown. 
        /// </remarks>
        /// <exception cref="ArgumentException"> if the <c>CityName</c> of <c>city</c> is null or empty</exception>
        private void ValidateCityNameNotNullOrEmpty(City city)
        {
            if (string.IsNullOrEmpty(city.CityName) || string.IsNullOrWhiteSpace(city.CityName))
            {
                throw new ArgumentException("City cannot be null or empty");
            }
        }

        /// <summary>
        /// Validates if the <c>CityName</c> of <c>city</c> is letters only. 
        /// </summary>
        /// <param name="city">city that is being validated</param>
        /// <remarks>
        /// This method will return void if validation succeeds. If validation fails, then an <c>ArgumentException</c> will be thrown. 
        /// </remarks>
        /// <exception cref="ArgumentException"> if the <c>CityName</c> of <c>city</c> is not letters only</exception>
        private void ValidateCityNameLettersOnly(City city)
        {
            if (city.CityName.Any(c => !char.IsLetter(c)))
            {
                throw new ArgumentException("City Name must only contain letters");
            }
        }

        /// <summary>
        /// Validates if the <c>ZipCode</c> of <c>city</c> is a valid zipcode. 
        /// </summary>
        /// <param name="city">city that is being validated</param>
        /// <remarks>
        /// This method will return void if validation succeeds. If validation fails, then an <c>ArgumentException</c> will be thrown. 
        /// </remarks>
        /// <exception cref="ArgumentException"> if the <c>CityName</c> of <c>city</c> is not 4 digits or if zipcode is negative</exception>
        private void ValidateZipCode(City city)
        {
            if (city.ZipCode < 0)
            {
                throw new ArgumentException("ZipCode cannot be negative");
            }

            if (city.ZipCode.ToString().Length != 4)
            {
                throw new ArgumentException("ZipCode must be 4 digits, ex. 8700");
            }
        }
    }
}