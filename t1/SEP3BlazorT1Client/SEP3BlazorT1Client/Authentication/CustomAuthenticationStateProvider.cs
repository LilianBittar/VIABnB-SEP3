
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
        private readonly IGuestService _guestService;
        private Host cachedHost;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IHostService _hostService, IGuestService _guestService)
        {
            this.jsRuntime = jsRuntime;
            this._hostService = _hostService;
            this._guestService = _guestService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedHost == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    var tmp = JsonSerializer.Deserialize<Host>(userAsJson);
                    await ValidateLoginAsHost(tmp.Email, tmp.Password);
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedHost);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLoginAsHost(string email, string password)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("Enter email");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            
            Console.WriteLine("Validating log in as a host.");
                
            ClaimsIdentity identity = new();
            try
            {
                Console.WriteLine(1);
                var user = await _hostService.ValidateHostAsync(email, password);
                Console.WriteLine(2);
                if (user == null) throw new Exception("Email or password are not correct");
                Console.WriteLine(user.Email);
                Console.WriteLine(3);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedHost = user;
            }
            catch (Exception e)
            {
                throw e;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public async Task ValidateLoginAsGuest(string studentNumber,string password)
        {
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            if (string.IsNullOrEmpty(studentNumber)) throw new Exception("Enter student number");
            
            Console.WriteLine("Validating log in as a guest.");
                
            ClaimsIdentity identity = new();
            try
            {
                Console.WriteLine("1");
                Console.WriteLine(studentNumber);
                Console.WriteLine(password);
                Guest user = await _guestService.ValidateGuestAsync(studentNumber, password);
                Console.WriteLine("11");
                if (user == null) throw new Exception("Password or student number are not correct");
                Console.WriteLine("1111");
                identity = SetupClaimsForUserAsGuest(user);
                Console.WriteLine("111111");
                string serialisedData = JsonSerializer.Serialize(user);
                Console.WriteLine("222");
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedHost = user;
                Console.WriteLine("1o");
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
            // make an if statment to see if guest found already in the system, so he should have a claim permission
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

        private ClaimsIdentity SetupClaimsForUserAsGuest(Guest guest)
        {
           
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, guest.FirstName));
            claims.Add(new Claim("Lastname", guest.LastName));
            claims.Add(new Claim("Email", guest.Email));
            claims.Add(new Claim("Password", guest.Password));
            claims.Add(new Claim("Id", guest.Id.ToString()));
            claims.Add(new Claim("PhoneNumber", guest.PhoneNumber));
            claims.Add(new Claim("Cpr", guest.Cpr));
            claims.Add(new Claim("ProfileImageUrl", guest.ProfileImageUrl));
            claims.Add(new Claim("IsApprovedHost", guest.IsApprovedHost.ToString()));
            claims.Add(new Claim("viaId", guest.ViaId.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}

