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
        private readonly CreateRentRequestValidator _createRentRequestValidator;

        public RentalService(IRentRequestRepository rentRequestRepository, CreateRentRequestValidator createRentRequestValidator)
        {
            _rentRequestRepository = rentRequestRepository;
            _createRentRequestValidator = createRentRequestValidator;
        }

        /// <summary>
        /// This implementation of the IRentalService uses an <see cref="CreateRentRequestValidator"/> for validating
        /// the business logic of creating a new RentRequest. 
        /// </summary>
        public async Task<RentRequest> CreateRentRequest(RentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Request cannot be null");
            }
            _createRentRequestValidator.ValidateRentRequest(request);
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