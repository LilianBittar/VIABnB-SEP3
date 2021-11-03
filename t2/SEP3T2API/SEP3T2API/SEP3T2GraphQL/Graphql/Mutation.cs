using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services;

namespace SEP3T2GraphQL.Graphql
{
    public class Mutation
    {
        public async Task<Residence> CreateResidence(Residence residence, [ScopedService] IResidenceService residenceService)
        {
            return await residenceService.CreateResidenceAsync(residence); 
        }
    }
}