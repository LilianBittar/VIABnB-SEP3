using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class GuestRepository : IGuestRepository
    {
        public async Task<Guest> GetGuestById(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{Uri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync()); 
            }

            var fetchedGuest = JsonSerializer.Deserialize<Guest>(await response.Content.ReadAsStringAsync());
            return fetchedGuest;
        }

        public Task<Guest> GetGuestByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Guest> UpdateGuest(Guest guest)
        {
            var guestAsJson = JsonSerializer.Serialize(guest);
            HttpContent content = new StringContent(guestAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PatchAsync(Uri + $"/{guest.Id}/approval", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            return guest;
        }

        public async Task<IList<Guest>> GetAllGuests()
        {
            HttpResponseMessage response = await _client.GetAsync($"{Uri}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync()); 
            }
            var fetchedGuests = JsonSerializer.Deserialize<List<Guest>>(await response.Content.ReadAsStringAsync());
            return fetchedGuests;
        }

        public async Task<IList<Guest>> GetAllNotApprovedGuests()
        {
            HttpResponseMessage response = await _client.GetAsync(Uri + $"/notApproved");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
            var result = await response.Content.ReadAsStringAsync();
            var guestListToReturn = JsonSerializer.Deserialize<List<Guest>>(result,  new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return guestListToReturn;
        }
    }
}