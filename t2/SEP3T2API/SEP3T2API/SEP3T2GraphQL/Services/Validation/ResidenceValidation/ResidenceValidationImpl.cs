using System;
using System.Collections.Generic;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.ResidenceValidation
{
    public class ResidenceValidationImpl : IResidenceValidation
    {
        public bool IsValidAddress(Address address)
        {
            if ((address.Id == null || address.Id < 0) ||
                (string.IsNullOrEmpty(address.StreetName)) || 
                (string.IsNullOrEmpty(address.HouseNumber)) || 
                (string.IsNullOrEmpty(address.CityName) || 
                 IsLettersOnly(address.CityName)) || 
                (address.ZipCode == null || 
                 address.ZipCode < 0 || 
                 address.ZipCode > 9999))
            {
                return false;
            }

            return true;
        }

        public bool IsValidRules(IList<Rule> rules)
        {
            foreach (var rule in rules)
            {
                if ((rule.Id == null || rule.Id < 0) || 
                    string.IsNullOrEmpty(rule.Description))
                {
                    return false;
                }

            }
            return true;
        }

        public bool IsValidFacilities(IList<Facility> facilities)
        {
            foreach (var facility in facilities)
            {
                if ((facility.Id == null || facility.Id < 0) || 
                    string.IsNullOrEmpty(facility.Name))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidResidence(Residence residence)
        {
            if ((residence.Id == null || residence.Id < 0) || 
                (residence.Address == null ||
                 IsValidAddress(residence.Address)) || 
                (string.IsNullOrEmpty(residence.Description)) ||
                (string.IsNullOrEmpty(residence.Type)) ||
                (residence.AverageRating == null || 
                 residence.AverageRating < 0) || 
                (residence.IsAvailable == null) || 
                (residence.PricePerNight == null || 
                 residence.PricePerNight < 0) ||
                (residence.Rules == null || 
                 IsValidRules(residence.Rules)) || 
                (residence.Facilities == null || 
                 IsValidFacilities(residence.Facilities)) || 
                (residence.AvailableFrom == null || 
                 residence.AvailableFrom < DateTime.Now) ||
                (residence.AvailableTo == null || 
                 residence.AvailableTo < DateTime.Now))
            {
                return false;
            }

            return true;
        }

        public bool IsLettersOnly(string arg)
        {
            foreach (char c in arg)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }

            }
            return true;
        }
    }
}