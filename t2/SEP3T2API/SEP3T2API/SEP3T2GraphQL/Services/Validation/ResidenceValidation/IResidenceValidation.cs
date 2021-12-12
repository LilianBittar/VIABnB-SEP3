using System;
using System.Collections.Generic;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.ResidenceValidation
{
    public interface IResidenceValidation
    {
        bool IsValidAddress(Address address);
        bool IsValidResidence(Residence residence);
        bool IsValidAvailabilityPeriod(DateTime? startDate, DateTime? EndDate);

        bool IsValidResidenceForUpdate(Residence residence);

    }
}