using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Graphql
{
    public class Query
    {
        public async Task<Residence> GetResidence(int id, [Service]IResidenceRepository residenceRepository)
        {
            return await residenceRepository.GetResidenceById(id); 
        }
        
    }
}