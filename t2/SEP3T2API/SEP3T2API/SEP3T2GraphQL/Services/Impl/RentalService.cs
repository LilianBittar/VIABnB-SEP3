using System;
using System.Collections.Generic;
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
        public Task<RentRequest> CreateRentRequest(RentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Request cannot be null");
            }
            

            return null; 
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

        public Task<RentRequest> GetRentRequestAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}