using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public class RentalService : IRentalService
    {
        private readonly IRentRequestRepository _rentRequestRepository;

        /// <summary>
        /// This implementation of the IRentalService uses an <see cref="RentRequestValidator"/> for validating
        /// the business logic that does not require any services. All business logic that requires calling other services
        /// is handled inside this method itself.  
        /// </summary>
        public async Task<RentRequest> CreateRentRequest(RentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Request cannot be null");
            }

            RentRequestValidator.ValidateRentRequest(request);
            var allRequestsForSameResidence = await GetAllRentRequestByResidenceId(request.Residence.Id);
            if (allRequestsForSameResidence.Any(r =>
                (r.StartDate == request.StartDate && r.EndDate == request.EndDate) &&
                (r.Status == RentRequestStatus.Approved)))
            {
                throw new ArgumentException("Approved rent request for same rent period already exists"); 
            }

            return await _rentRequestRepository.CreateAsync(request);
        }

        public Task<RentRequest> ApproveRentRequestAsync(RentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<RentRequest> RejectRentRequestAsync(RentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RentRequest>> GetAllRentRequestByResidenceId(int residenceId)
        {
            throw new NotImplementedException();
        }

        public Task<RentRequest> GetRentRequestAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}