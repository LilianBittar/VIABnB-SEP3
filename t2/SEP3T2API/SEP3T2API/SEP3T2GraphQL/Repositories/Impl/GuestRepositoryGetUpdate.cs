using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEP3T2GraphQL.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class GuestRepository : IGuestRepository
    {
        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            var response = await _client.GetAsync($"{Uri}/{id}");
            await HandleErrorResponse(response);
            var fetchedGuest = JsonSerializer.Deserialize<Guest>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return fetchedGuest;
        }

        public async Task<Guest> GetGuestByStudentNumberAsync(int studentNumber)
        {
            
            var response = await _client.GetAsync($"{Uri}?studentNumber={studentNumber}");
            await HandleErrorResponse(response);
            var fetchedGuests = JsonConvert.DeserializeObject<List<Guest>>(await response.Content.ReadAsStringAsync());
            var fetchedGuest = fetchedGuests[0];
            return fetchedGuest;
        }

        public async Task<Guest> GetGuestByEmailAsync(string email)
        {
            var response = await _client.GetAsync($"{Uri}?email={email}");
            await HandleErrorResponse(response);
            var result = await response.Content.ReadAsStringAsync();
            
            var guestToReturn = JsonSerializer.Deserialize<Guest[]>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (!guestToReturn.Any())
            {
                return null; 
            }
            return guestToReturn[0];
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            var response = await _client.GetAsync($"{Uri}");
            await HandleErrorResponse(response);
            var fetchedGuests = JsonSerializer.Deserialize<List<Guest>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions(){PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return fetchedGuests;
        }

        public async Task<IEnumerable<Guest>> GetAllNotApprovedGuestsAsync()
        {
            var response = await _client.GetAsync(Uri + $"/notApproved");
            await HandleErrorResponse(response);
            var result = await response.Content.ReadAsStringAsync();
            var guestListToReturn = JsonSerializer.Deserialize<List<Guest>>(result,  new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return guestListToReturn;
        }

        public async Task<Guest> UpdateGuestStatusAsync(Guest guest)
        {
            var guestAsJson = JsonSerializer.Serialize(guest, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(guestAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync($"{Uri}/{guest.Id}/approval", content);
            await HandleErrorResponse(response);

            var updatedGuest = JsonSerializer.Deserialize<Guest>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return updatedGuest;
        }
    }
}