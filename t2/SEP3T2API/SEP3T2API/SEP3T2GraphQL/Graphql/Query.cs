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
        public Query(IResidenceService residenceService)
        {
            _residenceService = residenceService; 
        }
        public async Task<Residence> GetResidence(int id)
        {
            return await _residenceService.GetResidenceByIdAsync(id); 
        }
        
    }
}