using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes.UserResponseTypes;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlUserService : IUserService
    {
        private const string Url = "https://localhost:5001/graphql";
        private readonly GqlClient _client = new GqlClient(Url) {EnableLogging = true};
        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var query = new GqlQuery()
            {
                Query = @"query($userEmail:String){
                              userByEmail(email:$userEmail){
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                              }
                            }",
                Variables = new {userEmail = email}
            };
            var response = await _client.PostQueryAsync<UserByEmailResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.User;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = new GqlQuery()
            {
                Query = @"query($userId:Int!){
                              userById(id:$userId){
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                              }
                            }",
                Variables = new {userId = id}
            };
            var response = await _client.PostQueryAsync<UserByIdResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.User;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var query = new GqlQuery()
            {
            Query = @"query{
                        allUsers{
                           id
                           email
                           password
                           firstName
                           lastName
                           phoneNumber
                         }
                       }"
        };
        var response = await _client.PostQueryAsync<AllUsersResponseType>(query);
        HandleErrorResponse(response);
            return response.Data.Users;
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            var query = new GqlQuery()
            {
                Query = @"query($userEmail:String,$userPassword:String){
                              validateUser(email:$userEmail,password:$userPassword){
                                id
                                email
                                password
                                firstName
                                lastName
                                phoneNumber
                              }
                            }",
                Variables = new {userEmail=email, userPassword=password}
            };
            var response = await _client.PostQueryAsync<UserValidationResponseType>(query);
            HandleErrorResponse(response);
            return response.Data.User;
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
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