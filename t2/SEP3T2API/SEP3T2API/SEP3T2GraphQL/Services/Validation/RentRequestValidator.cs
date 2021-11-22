using System;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation
{
    public static class RentRequestValidator
    {
        public static void ValidateRentRequest(RentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Request cannot be null");
            }
            
            ValidateResidenceAvailability(request);
            ValidateRentPeriod(request);
            ValidateNumberOfGuests(request);
        }

        private static void ValidateNumberOfGuests(RentRequest request)
        {
            //TODO: Add max number of guests for an residence and then check if the requests number of guests exceeds the max. 
            if (request.NumberOfGuests < 1)
            {
                throw new ArgumentException("Number of guests must be over 0");
            }
        }

        /// <summary>
        /// Validates the rent period of the request. Uses the DateTime.Compare static method to compare
        /// the start date and end date. <see cref="DateTime"/> 
        /// </summary>
        /// <param name="request">The request which is being validated</param>
        /// <exception cref="ArgumentException">If the start date and end date is the same</exception>
        private static void ValidateRentPeriod(RentRequest request)
        {
            if (DateTime.Compare(request.StartDate, request.EndDate) == 0)
            {
                throw new ArgumentException("Start date and end date of the rent period cannot be the same");
            }

            if (DateTime.Compare(request.EndDate, request.StartDate) < 0)
            {
                throw new ArgumentException("End date cannot be earlier than start date")
            }

            if (DateTime.Compare(request.StartDate, DateTime.Now) < 0)
            {
                throw new ArgumentException("Start date cannot be earlier than today");
            }

            if (DateTime.Compare(request.EndDate, DateTime.Now) < 0)
            {
                throw new ArgumentException("End date cannot be earlier than today"); 
            }

            if (DateTime.Compare(request.StartDate, request.Residence.AvailableFrom.Value) < 0)
            {
                throw new ArgumentException(
                    "Start date of request cannot be earlier than the residence's available from date");
            }

            if (DateTime.Compare(request.EndDate, request.Residence.AvailableTo.Value) > 0)
            {
                throw new ArgumentException(
                    "End date of request cannot be later than the residence's available to date"); 
            }
        }


        private static void ValidateResidenceAvailability(RentRequest request)
        {
            if (!request.Residence.IsAvailable)
            {
                throw new ArgumentException("The residence is not available for rent"); 
            }
        }
    }
}