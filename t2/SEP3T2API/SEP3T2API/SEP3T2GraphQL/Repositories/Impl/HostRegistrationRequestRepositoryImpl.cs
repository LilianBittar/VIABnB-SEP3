// using System;
// using System.Collections.Generic;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;
// using SEP3T2GraphQL.Models;
//
// namespace SEP3T2GraphQL.Repositories.Impl
// {
//     public class HostRegistrationRequestRepositoryImpl : IHostRegistrationRequestRepository
//     {
//         private const string uri = "http://localhost:8080";
//         private HttpClient client;
//
//         public HostRegistrationRequestRepositoryImpl()
//         {
//             client = new HttpClient();
//         }
//
//         public async Task<IList<HostRegistrationRequest>> GetAllHostRegistrationRequests()
//         {
//             HttpResponseMessage response = await client.GetAsync(uri + $"/hostregistrationrequests");
//             if (!response.IsSuccessStatusCode)
//             {
//                 throw new Exception($"$Error: {response.StatusCode}, {response.ReasonPhrase}");
//             }
//
//             string result = await response.Content.ReadAsStringAsync();
//             List<HostRegistrationRequest> requests = JsonSerializer.Deserialize<List<HostRegistrationRequest>>(result,
//                 new JsonSerializerOptions
//                 {
//                     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//                 });
//             return requests;
//         }
//
//         public async Task<HostRegistrationRequest> GetHostRegistrationRequestByHostId(int hostId)
//         {
//             HttpResponseMessage response = await client.GetAsync(uri + $"/hostregistrationrequests/host/{hostId}");
//             if (!response.IsSuccessStatusCode)
//             {
//                 throw new Exception($"$Error: {response.StatusCode}, {response.ReasonPhrase}");
//             }
//
//             string result = await response.Content.ReadAsStringAsync();
//             HostRegistrationRequest request = JsonSerializer.Deserialize<HostRegistrationRequest>(result,
//                 new JsonSerializerOptions
//                 {
//                     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//                 });
//             return request;
//         }
//
//         public async Task<HostRegistrationRequest> GetHostRegistrationRequestById(int requestId)
//         {
//             HttpResponseMessage response = await client.GetAsync(uri + $"/hostregistrationrequests/{requestId}");
//             if (!response.IsSuccessStatusCode)
//             {
//                 throw new Exception($"$Error: {response.StatusCode}, {response.ReasonPhrase}");
//             }
//
//             string result = await response.Content.ReadAsStringAsync();
//             HostRegistrationRequest request = JsonSerializer.Deserialize<HostRegistrationRequest>(result,
//                 new JsonSerializerOptions
//                 {
//                     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//                 });
//             return request;
//         }
//
//         public async Task UpdateHostRegistrationRequest(HostRegistrationRequest request)
//         {
//             string requestAsJson = JsonSerializer.Serialize(request);
//             HttpContent content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
//             HttpResponseMessage response =
//                 await client.PatchAsync(uri + $"/hostregistrationrequests/{request.Id}", content);
//             if (!response.IsSuccessStatusCode)
//             {
//                 throw new Exception($"$Error: {response.StatusCode}, {response.ReasonPhrase}");
//             }
//         }
//     }
// }