using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;

namespace SEP3T2GraphQL.Graphql
{
    public class Query
    {
        private readonly IResidenceService _residenceService;
        private readonly IHostService _hostService;
        private readonly IGuestService _guestService;
        private readonly IRentalService _rentalService;
        public Query(IResidenceService residenceService, IHostService hostService, IGuestService guestService, IRentalService rentalService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
            _guestService = guestService;
            _rentalService = rentalService; 
        }
        public async Task<Residence> GetResidence(int id)
        {
            return await _residenceService.GetResidenceByIdAsync(id); 
        }

        public async Task<IList<Host>> GetAllNotApprovedHost()
        {
            return await _hostService.GetAllNotApprovedHostsAsync();
        }

        public async Task<IList<Guest>> GetAllNotApprovedGuest()
        {
            Console.WriteLine(JsonSerializer.Serialize(_guestService.GetAllNotApprovedGuests()));
            return await _guestService.GetAllNotApprovedGuests();
        }
        
        public async Task<Host> GetHostById(int id)
        {
            return await _hostService.GetHostById(id); 
        }
    }
}