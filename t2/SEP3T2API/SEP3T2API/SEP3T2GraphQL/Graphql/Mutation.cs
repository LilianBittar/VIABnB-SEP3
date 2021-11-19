using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services;

namespace SEP3T2GraphQL.Graphql
{
    public class Mutation
    {
        private IResidenceService _residenceService;
        private IHostService _hostService;
        public Mutation(IResidenceService residenceService, IHostService hostService)
        {
            _residenceService = residenceService;
            _hostService = hostService;
        }
        public async Task<Residence> CreateResidence(Residence residence)
        {
            return await _residenceService.CreateResidenceAsync(residence); 
        }

        public async Task<Host> UpdateHostStatus(Host host)
        {
            return await _hostService.UpdateHost(host);
        }
    }
}