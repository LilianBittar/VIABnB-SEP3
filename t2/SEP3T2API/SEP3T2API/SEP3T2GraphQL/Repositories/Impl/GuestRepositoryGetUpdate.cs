using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public Task<Guest> UpdateGuest(Guest guest)
        {
            throw new System.NotImplementedException();
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

        public Task<IList<Guest>> GetAllNotApprovedGuests()
        {
            throw new System.NotImplementedException();
        }
    }
}