using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.AdminResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlAdministrationService : IAdministrationService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new(Url) {EnableLogging = true};

        public async Task<Administrator> GetAdminByEmailAsync(string email)
        {
            GqlQuery adminQuery = new()
            {
                Query =
                    @"query($aEmail:String){adminByEmail(email:$aEmail){id,firstName,lastName,email,phoneNumber,password}}",
                Variables = new {aEmail = email}
            };
            var response = await _client.PostQueryAsync<AdminResponseType>(adminQuery);
            HandleErrorResponse(response);
            return response.Data.Administrator;
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