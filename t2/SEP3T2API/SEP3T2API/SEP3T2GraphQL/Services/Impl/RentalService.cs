using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            await _createRentRequestValidator.ValidateRentRequest(request);
            return await _rentRequestRepository.CreateAsync(request);
        }

        public async Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync()
        {
            var rentRequestListToReturn = await _rentRequestRepository.GetAllAsync();
            if (rentRequestListToReturn == null)
            {
                throw new ArgumentException("Rent request list is null");
            }

            return rentRequestListToReturn;
        }

        public Task<IEnumerable<RentRequest>> GetAllRentRequestByResidenceId(int residenceId)
        {
            throw new NotImplementedException();
        }

        public async Task<RentRequest> GetRentRequestAsync(int id)
        {
            var rentRequestListToReturn = await _rentRequestRepository.GetAsync(id);
            if (rentRequestListToReturn == null)
            {
                throw new ArgumentException("Rent request list is null");
            }

            return rentRequestListToReturn;
        }

        public async Task<RentRequest> UpdateRentRequestStatusAsync(RentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Rent request can't be null");
            }

            var updatedRequest = await _rentRequestRepository.UpdateRentRequestStatusAsync(request);
            await _createRentRequestValidator.ValidateRentRequest(request);
            return updatedRequest;
        }

        public async Task<IEnumerable<RentRequest>> GetAllNotAnsweredRentRequestAsync()
        {
            var rentRequestList = await _rentRequestRepository.GetAllNotAnsweredRentRequestAsync();
            if (rentRequestList == null)
            {
                throw new ArgumentException("Request list is null");
            }
            Console.WriteLine(JsonSerializer.Serialize(rentRequestList));
            return rentRequestList;
        }

        public async Task<IEnumerable<RentRequest>> GetRentRequestsByGuestId(int guestId)
        {
            return await _rentRequestRepository.GetRentRequestsByGuestId(guestId);
        }
    }
} 