
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using SEP3BlazorT1Client.Models;
using SEP3BlazorT1Client.Data;

namespace SEP3BlazorT1Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider 
    {
        
      private readonly IJSRuntime jsRuntime;
       private readonly IHostService _hostService;
        private Host cachedHost;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IHostService _hostService)
         {
             this.jsRuntime = jsRuntime;
             this._hostService = _hostService;
         }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
         {
             var identity = new ClaimsIdentity();
             if (cachedHost == null)
             {
                 string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                 if (!string.IsNullOrEmpty(userAsJson))
                 {
                     Host tmp = JsonSerializer.Deserialize<Host>(userAsJson);
                  ValidateLogin(tmp.Email, tmp.Password);
                 }
             }
             else
             {
                 identity = SetupClaimsForUser(cachedHost);
             }
        
           ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
             return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }
        
         public async Task ValidateLogin(string email, string password)
        {
             Console.WriteLine("Validating log in");
             if (string.IsNullOrEmpty(email)) throw new Exception("Enter email");
             if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
             ClaimsIdentity identity = new ClaimsIdentity();
             try
             {
                Host user = await _hostService.ValidateHostAsync(email, password);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedHost = user;
            }
            catch (Exception e)
            {
                throw e;
            }
        
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }
         
        public void Logout()
        {
            cachedHost = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        
        private ClaimsIdentity SetupClaimsForUser(Host host)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, host.FirstName));
            claims.Add(new Claim("Lastname", host.LastName));
            claims.Add(new Claim("Email", host.Email));
            claims.Add(new Claim("Password", host.Password));
            claims.Add(new Claim("Id", host.Id.ToString()));
            claims.Add(new Claim("PhoneNumber", host.PhoneNumber));
            claims.Add(new Claim("Cpr", host.Cpr));
            claims.Add(new Claim("ProfileImageUrl", host.ProfileImageUrl));
            claims.Add(new Claim("IsApprovedHost", host.IsApprovedHost.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
     
}
    }

