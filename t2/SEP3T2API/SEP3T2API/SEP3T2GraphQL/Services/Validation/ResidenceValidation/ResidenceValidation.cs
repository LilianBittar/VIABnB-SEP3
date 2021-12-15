using System;
using System.Collections.Generic;
using System.Linq;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.ResidenceValidation
{
    public class ResidenceValidation : IResidenceValidation
    {
        public bool IsValidAddress(Address address)
        {
            if (address != null &&
                ((address.Id != null && address.Id >= 0) &&
                 (!string.IsNullOrEmpty(address.StreetName)) &&
                 (!string.IsNullOrEmpty(address.StreetNumber)) &&
                 (!string.IsNullOrEmpty(address.City.CityName) && IsLettersOnly(address.City.CityName)) &&
                 ((address.City.ZipCode is >= 1000 and <= 9999) && address.City.ZipCode != null)))
            {
                return true;
            }

            throw new ArgumentException("Invalid address");
        }

        private static bool IsValidRules(IList<Rule> rules)
        {
            if (rules != null && (rules.All(rule => !string.IsNullOrEmpty(rule.Description))))
            {
                return true;
            }

            throw new ArgumentException("Invalid rules");
        }

        private static bool IsValidFacilities(IList<Facility> facilities)
        {
            if (facilities != null &&
                (facilities.All(facility =>
                    (facility.Id >= 0) &&
                    (!string.IsNullOrEmpty(facility.Name))
                )))
            {
                return true;
            }

            throw new ArgumentException("Invalid facilities");
        }

        public bool IsValidResidence(Residence residence)
        {
            if ((residence != null) &&
                ((residence.Id != null && residence.Id >= 0) &&
                 (IsValidAddress(residence.Address)) &&
                 (!string.IsNullOrEmpty(residence.Description)) &&
                 (!string.IsNullOrEmpty(residence.Type)) &&
                 (residence.IsAvailable != null) &&
                 (residence.PricePerNight >= 0) &&
                 IsValidRules(residence.Rules) &&
                 (IsValidFacilities(residence.Facilities)) &&
                 IsValidAvailabilityPeriod(residence.AvailableFrom, residence.AvailableTo)
                ) && residence.MaxNumberOfGuests > 0)
            {
                return true;
            }

            throw new ArgumentException("Invalid Residence");
        }

        private static bool IsLettersOnly(string arg)
        {
            if (arg.All(char.IsLetter))
            {
                return true;
            }

            throw new ArgumentException($"Invalid string: {arg}");
        }

        public bool IsValidAvailabilityPeriod(DateTime? startDate, DateTime? EndDate)
        {
          
            if (startDate == null || EndDate == null)
            {
                throw new ArgumentException("Start and end date must be picked");
            }

            if (startDate.Value.Date < DateTime.Today || EndDate.Value.Date < DateTime.Today)
            {
                throw new ArgumentException("Rent period cannot be in the past");
            }

            if (startDate.Value.Date > EndDate.Value.Date)
            {
                throw new ArgumentException("Start date must be before end date");
            }

            return true;
        }

        public bool IsValidResidenceForUpdate(Residence residence)
        {
            if ((residence != null) &&
                ((residence.Id != null && residence.Id >= 0) &&
                 (!string.IsNullOrEmpty(residence.Description)) &&
                 (!string.IsNullOrEmpty(residence.Type)) &&
                 (residence.IsAvailable != null) &&
                 (residence.PricePerNight >= 0) &&
                 IsValidRules(residence.Rules) &&
                 (IsValidFacilities(residence.Facilities)) &&
                 IsValidAvailabilityPeriod(residence.AvailableFrom, residence.AvailableTo)
                ) && residence.MaxNumberOfGuests > 0)
            {
                return true;
            }

            throw new ArgumentException("Invalid Residence");
        }
    }
}