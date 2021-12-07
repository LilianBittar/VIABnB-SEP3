using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.FacilityResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlFacilityService : IFacilityService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly IGqlClient _client = new GqlClient(Url); 
        public Task<Facility> CreateFacility(Facility facility)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Facility>> GetAllFacilities()
        {
            var query = new GqlQuery()
            {
                Query = @"query{
                          allFacilities{
                            id,
                            name
                          }
                        }
                        "
            };
            var response = await _client.PostQueryAsync<FacilityListResponseType>(query);
            return response.Data.Facilities; 
        }

        public Task<Facility> GetFacilityById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}