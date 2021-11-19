using System.Collections.Generic;
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
        public Query(IResidenceService residenceService, IHostService hostService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
        }
        public async Task<Residence> GetResidence(int id)
        {
            return await _residenceService.GetResidenceByIdAsync(id); 
        }

        public async Task<List<Host>> GetAllNotApprovedHost()
        {
            return await _hostService.GetAllNotApprovedHostsAsync();
        }
    }
}