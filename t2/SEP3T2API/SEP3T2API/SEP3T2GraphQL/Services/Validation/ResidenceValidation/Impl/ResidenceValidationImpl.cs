﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.ResidenceValidation
{
    public class ResidenceValidationImpl : IResidenceValidation
    {
        public bool IsValidAddress(Address address)
        {
            if (address != null && 
                ((address.Id != null && address.Id >= 0) &&
                 (!string.IsNullOrEmpty(address.StreetName)) &&
                 (!string.IsNullOrEmpty(address.StreetNumber)) &&
                 (!string.IsNullOrEmpty(address.HouseNumber)) &&
                 (!string.IsNullOrEmpty(address.CityName) && IsLettersOnly(address.CityName)) &&
                 ((address.ZipCode is >= 1000 and <= 9999) && address.ZipCode != null)))
            {
                return true;
            }
            throw new ArgumentException("Invalid address");
        }

        public bool IsValidRules(IList<Rule> rules)
        {
            if (rules != null && (rules.All(rule => (rule.Id >= 0) && !string.IsNullOrEmpty(rule.Description))))
            {
                return true;
            }
            throw new ArgumentException("Invalid rules");
        }

        public bool IsValidFacilities(IList<Facility> facilities)
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
                 ((residence.AverageRating >= 0) &&
                  (residence.IsAvailable != null) &&
                  (residence.PricePerNight >= 0) &&
                  IsValidRules(residence.Rules) &&
                  (IsValidFacilities(residence.Facilities)) &&
                  (residence.AvailableFrom != null && residence.AvailableFrom >= DateTime.Now) &&
                  (residence.AvailableTo != null && residence.AvailableTo >= DateTime.Now))))
            {
                return true;
            }
            throw new ArgumentException("Invalid Residence");
        }

        public bool IsLettersOnly(string arg)
        {
            if (arg.All(char.IsLetter))
            {
                return true;
            }
            throw new ArgumentException($"Invalid string: {arg}");

        }
        
    }
}