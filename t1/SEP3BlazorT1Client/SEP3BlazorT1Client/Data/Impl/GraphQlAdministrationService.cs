using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlAdministrationService : IAdministrationService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new(Url) {EnableLogging = true};

        public async Task<Administrator> GetAdminByEmail(string email)
        {
            GqlQuery adminQuery = new()
            {
                Query =
                    @"query($aEmail:String){adminByEmail(email:$aEmail){id,firstName,lastName,email,phoneNumber,password}}",
                Variables = new {aEmail = email}
            };
            var response = await _client.PostQueryAsync<AdminResponseType>(adminQuery);
            if (response == null)
            {
                Console.WriteLine(response.Errors);
                throw new ArgumentException("Email incorrect");
            }

            return response.Data.Administrator;
        }

        public async Task<IEnumerable<Administrator>> GetAllAdmins()
        {
            var adminQuery = new GqlQuery()
            {
                Query = @"query{allAdmins{id,firstName,lastName,email,phoneNumber,password}}"
            };
            var response = await _client.PostQueryAsync<AdminListResponseType>(adminQuery);
            if (response == null)
            {
                Console.WriteLine(response.Errors);
                throw new Exception("Admin list can't be null");
            }

            return response.Data.Administrators;
        }

        public async Task<Administrator> ValidateAdmin(string email, string password)
        {
            var validateAdminQuery = new GqlQuery()
            {
                Query =
                    @"query($aEmail:String,$aPassword:String){validateAdmin(email:$aEmail,password:$aPassword){id,firstName,lastName,email,phoneNumber,password}}",
                Variables = new {aEmail = email, aPassword = password}
            };
            var response = await _client.PostQueryAsync<ValidateAdminResponseType>(validateAdminQuery);
            if (response.Data.Administrator == null)
            {
                Console.WriteLine(response.Errors);
                throw new ArgumentException("Incorrect password or email. Please try again");
            }

            return response.Data.Administrator;
        }
    }
}