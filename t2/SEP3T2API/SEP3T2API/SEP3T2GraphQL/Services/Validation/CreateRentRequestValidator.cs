using System;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    /// <summary>
    /// Utility class for validating the CreateRentRequest event.
    /// </summary>
    public class CreateRentRequestValidator
    {
        private readonly IRentRequestRepository _rentRequestRepository;

        public CreateRentRequestValidator(IRentRequestRepository rentRequestRepository)
        {
            _rentRequestRepository = rentRequestRepository;
        }

        /// <summary>
        /// Validates an request for residence availability, number of guests, rent period overlaps and rent period. 
        /// </summary>
        /// <remarks>
        /// Throws ArgumentException if request is not valid.
        /// If request is valid then no exceptions are thrown and void is returned
        /// </remarks>
        /// <param name="request">The request which is to be validated</param>
        /// <exception cref="ArgumentException">Request is null</exception>
        /// <exception cref="ArgumentException">Number of guests is less than 1</exception>
        /// <exception cref="ArgumentException">Number of guests exceeds the max specified by host</exception>
        /// <exception cref="ArgumentException">if the start date and end date is the same</exception>
        /// <exception cref="ArgumentException">if end date is earlier than start date</exception>
        /// <exception cref="ArgumentException">if start date is earlier than today</exception>
        /// <exception cref="ArgumentException">if start date of request is same as residence's available to date</exception>
        /// <exception cref="ArgumentException">if end date is earlier than today</exception>
        /// <exception cref="ArgumentException">if rent period of request is outside the available from and available to date of the residence</exception>
        /// <exception cref="ArgumentException">If residence is not available</exception>
        /// <exception cref="ArgumentException">If approved rent request exist for request's residence in same rent period as the request.</exception>
        public async Task ValidateRentRequest(RentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Request cannot be null");
            }

            ValidateResidenceAvailability(request);
            ValidateRentPeriod(request);
            ValidateNumberOfGuests(request);
            await ValidateRentPeriodOverlaps(request);
        }

        /// <summary>
        /// Validates if the number of guests is less than 1 or if the number of guests
        /// exceeds the maximum specified by the host. 
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="ArgumentException">Number of guests is less than 1</exception>
        /// <exception cref="ArgumentException">Number of guests exceeds the max specified by host</exception>
        private void ValidateNumberOfGuests(RentRequest request)
        {
            if (request.NumberOfGuests < 1)
            {
                throw new ArgumentException("Number of guests must be over 0");
            }

            if (request.NumberOfGuests > request.Residence.MaxNumberOfGuests)
            {
                throw new ArgumentException("Number of guests exceeds the maximum allowed for residence");
            }
        }

        /// <summary>
        /// Validates the rent period of the request. Uses the DateTime.Compare static method to compare
        /// the start date and end date. <see cref="DateTime"/> 
        /// </summary>
        /// <param name="request">The request which is being validated</param>
        /// <exception cref="ArgumentException">if the start date and end date is the same</exception>
        /// <exception cref="ArgumentException">if end date is earlier than start date</exception>
        /// <exception cref="ArgumentException">if start date is earlier than today</exception>
        /// <exception cref="ArgumentException">if end date is earlier than today</exception>
        /// <exception cref="ArgumentException">if rent period of request is outside the available from and available to date of the residence</exception>
        /// <exception cref="ArgumentException">if start date of request is same as residence's available to date</exception>
        private void ValidateRentPeriod(RentRequest request)
        {
            //TODO: Refactor the boolean expressions to separate methods with descriptive names for more readability.  
            if (request.StartDate == null || request.EndDate == null)
            {
                throw new ArgumentException("Start date and end date is required");
            }
            if (request.StartDate.Date == request.EndDate.Date)
            {
                throw new ArgumentException("Start date and end date of the rent period cannot be the same");
            }

            if (request.EndDate.Date < request.StartDate.Date)
            {
                throw new ArgumentException("End date cannot be earlier than start date");
            }

            if (request.StartDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Start date cannot be earlier than today");
            }

            if (request.EndDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("End date cannot be earlier than today");
            }

            if (request.StartDate < request.Residence.AvailableFrom.Value.Date)
            {
                throw new ArgumentException(
                    "Start date of request cannot be earlier than the residence's available from date");
            }

            if (request.EndDate.Date > request.Residence.AvailableTo.Value.Date)
            {
                throw new ArgumentException(
                    "End date of request cannot be later than the residence's available to date");
            }

            if (request.StartDate.Date == request.Residence.AvailableTo.Value.Date)
            {
                throw new ArgumentException(
                    "Start date of request cannot be the same as the residence's available to date"); 
            }
        }

        /// <summary>
        /// Validates if the residence of the request is available. 
        /// </summary>
        /// <param name="request">The request which is being validated</param>
        /// <exception cref="ArgumentException">If residence is not available</exception>
        private void ValidateResidenceAvailability(RentRequest request)
        {
            if (!request.Residence.IsAvailable)
            {
                throw new ArgumentException("The residence is not available for rent");
            }
        }

        /// <summary>
        /// Validates if there exists any approved rent requests for the same residence in the same rent period
        /// as the method param.
        /// </summary>
        /// <param name="request">The request which is being validated</param>
        /// <exception cref="ArgumentException">If approved rent request exist for request's residence in same rent period as the request.</exception>
        private async Task ValidateRentPeriodOverlaps(RentRequest request)
        {
            var allRequests = await _rentRequestRepository.GetAllAsync();
            if (allRequests == null || allRequests.Count() == 0)
            {
                return;
            }
            
            // if (!allRequests.Any(r => r.Residence.Id == request.Residence.Id))
            // {
            //     return; 
            // }
            // var allRequestsForSameResidence = allRequests.Where(r => r!= null && r.Residence.Id == request.Residence.Id).ToList();
            //
            // if (allRequestsForSameResidence.Any(r =>
            //     (DateTime.Compare(r.StartDate.Date, request.StartDate.Date) == 0 &&
            //      DateTime.Compare(r.EndDate.Date, request.EndDate.Date) == 0) &&
            //     (r.Status == RentRequestStatus.Approved)))
            // {
            //     throw new ArgumentException("Approved rent request for same rent period already exists");
            // }
        }
    }
}