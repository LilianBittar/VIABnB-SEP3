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
        public async Task<RentRequest> CreateRentRequestAsync(RentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Request cannot be null");
            }
            await _createRentRequestValidator.ValidateRentRequest(request);
            return await _rentRequestRepository.CreateRentRequestAsync(request);
        }

        public async Task<IEnumerable<RentRequest>> GetAllRentRequestsAsync()
        {
            var rentRequestListToReturn = await _rentRequestRepository.GetAllRentRequestAsync();
            if (rentRequestListToReturn == null)
            {
                throw new ArgumentException("Rent request list is null");
            }

            return rentRequestListToReturn;
        }

        public async Task<RentRequest> GetRentRequestAsync(int id)
        {
            var rentRequestListToReturn = await _rentRequestRepository.GetRentRequestByIdAsync(id);
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
            return rentRequestList;
        }

        public async Task<IEnumerable<RentRequest>> GetRentRequestsByGuestIdAsync(int guestId)
        {
            return await _rentRequestRepository.GetRentRequestsByGuestIdAsync(guestId);
        }

        public async Task<IEnumerable<RentRequest>> GetRentRequestsByViaId(int viaId)
        {
            return await _rentRequestRepository.GetRentRequestsByGuestIdAsync(viaId);
        }
    }
} 