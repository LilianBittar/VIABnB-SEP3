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
        private IResidenceService _residenceService;
        private IHostService _hostService;
        private IGuestService _guestService;
        public Query(IResidenceService residenceService, IHostService hostService, IGuestService guestService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
            _guestService = guestService;
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
    }
}