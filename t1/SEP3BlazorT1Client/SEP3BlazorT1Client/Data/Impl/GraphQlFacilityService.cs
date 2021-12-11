using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.FacilityResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlFacilityService : IFacilityService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly IGqlClient _client = new GqlClient(Url); 
        public async Task<Facility> CreateResidenceFacility(Facility facility, int residenceId)
        {
            var query = new GqlQuery()
            {
                Query = @"mutation($nFacility:FacilityInput, $nResidenceId:Int!){
                              createResidenceFacility(facility:$nFacility, residenceId:$nResidenceId){
                                id
                                name
                              }
                            }",
                Variables = new {nFacility = facility, nResidenceId = residenceId}
            };
            var response = await _client.PostQueryAsync<CreateResidenceFacilityResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.Facility;
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

        public async Task<Facility> DeleteResidenceFacility(Facility facility, int residenceId)
        {
            var query = new GqlQuery()
            {
                Query = @"mutation($dFacility:FacilityInput, $dResidenceId:Int!){
                              deleteResidenceFacility(facility:$dFacility, residenceId:$dResidenceId){
                                id
                                name
                              }
                            }",
                Variables = new {dFacility = facility, dResidenceId = residenceId}
            };
            var response = await _client.PostQueryAsync<DeleteResidenceFacilityResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.Facility; 
        }
        
        private static void HandleErrorResponse<T>(GqlRequestResponse<T> response)
        {
            if (response.Errors != null)
            {
                // String manipulation to seperate the Error message from the sample error response. 
                Console.WriteLine(JsonConvert.SerializeObject(response.Errors));
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors).Split(",")[4]
                    .Split(":")[2]);
            }
        }
    }
}