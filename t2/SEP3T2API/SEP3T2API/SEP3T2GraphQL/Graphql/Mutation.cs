using System.Threading.Tasks;
using HotChocolate;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services;

namespace SEP3T2GraphQL.Graphql
{
    public class Mutation
    {
        public async Task CreateResidence(Residence residence, [ScopedService] IResidenceService residenceService)
        {
            await residenceService.CreateResidenceAsync(residence); 
        }
    }
}