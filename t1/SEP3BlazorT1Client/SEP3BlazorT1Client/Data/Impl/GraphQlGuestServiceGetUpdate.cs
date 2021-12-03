using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatQL.GraphQL.Client;
using CatQL.GraphQL.QueryResponses;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data.Impl.ResponseTypes;
using SEP3BlazorT1Client.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3BlazorT1Client.Data.Impl
{
    public partial class GraphQlGuestService : IGuestService
    {
        public Task<Guest> GetGuestById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Guest> GetGuestByEmail(string email)
        {
            var guestQuery = new GqlQuery()
            {
                Query =
                    @"query($wantedGuestEmail:String) {guestByEmail(email: $wantedGuestEmail){viaId,guestReviews{id,rating,text,hostEmail},isApprovedGuest,id, firstName,lastName,phoneNumber,email,password,hostReviews{id,rating,text,viaId},profileImageUrl,cpr,isApprovedHost}}",
                Variables = new {wantedGuestEmail = email}
            };
            var response = await _client.PostQueryAsync<GuestByEmailResponseType>(guestQuery);
            return response.Data.Guest;
        }

        public Task<Guest> UpdateGuest(Guest guest)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Guest>> GetAllGuests()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Guest>> GetAllNotApprovedGuests()
        {
            var guestQuery = new GqlQuery()
            {
                Query =
                    @"query {allNotApprovedGuest{viaId,guestReviews{id,rating,text,hostEmail},isApprovedGuest,id, firstName,lastName,phoneNumber,email,password,hostReviews{id,rating,text,viaId},profileImageUrl,cpr,isApprovedHost}}"
            };
            GqlRequestResponse<GuestListResponse> graphQlResponse =
                await _client.PostQueryAsync<GuestListResponse>(guestQuery);
            return graphQlResponse.Data.Guests;
        }

        public async Task<Host> UpdateGuestStatusAsync(Guest guest)
        {
            GqlQuery updateStatusMutation = new GqlQuery()
            {
                Query =
                    @"mutation($newGuest:GuestInput)
{updateGuestStatus(guest:$newGuest)
{viaId,guestReviews{id,rating,text,hostEmail},isApprovedGuest,id, 
firstName,lastName,phoneNumber,email,password,hostReviews
{id,rating,text,viaId},profileImageUrl,cpr,isApprovedHost}}",
                Variables = new {newGuest = guest}
            };
            var response = await _client.PostQueryAsync<UpdateGuestMutationResponseType>(updateStatusMutation);
            if (response.Errors != null)
            {
                throw new ArgumentException(JsonConvert.SerializeObject(response.Errors));
            }

            return response.Data.UpdateGuest;
        }
    }
}