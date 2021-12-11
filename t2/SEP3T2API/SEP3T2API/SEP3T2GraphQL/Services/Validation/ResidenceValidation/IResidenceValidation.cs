using System;
using System.Collections.Generic;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.ResidenceValidation
{
    public interface IResidenceValidation
    {
        bool IsValidAddress(Address address);
        bool IsValidRules(IList<Rule> rules);
        bool IsValidFacilities(IList<Facility> facilities);
        bool IsValidResidence(Residence residence);
        bool IsLettersOnly(string arg);

        bool IsValidAvailabilityPeriod(DateTime? startDate, DateTime? EndDate);

        bool IsValidResidenceForUpdate(Residence residence);

    }
}