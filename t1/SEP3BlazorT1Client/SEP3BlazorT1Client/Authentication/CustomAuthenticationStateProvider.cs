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
        private readonly IUserService _userService;
        private readonly IHostService _hostService;
        private readonly IGuestService _guestService;
        private readonly IAdministrationService _administrationService;

        private User cachedUser;

        private bool isAdmin = false;
        private bool isHost = false;
        private bool isGuest = false;
        
        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService, IHostService hostService, IGuestService guestService, IAdministrationService administrationService)
        {
            this.jsRuntime = jsRuntime;
            _userService = userService;
            _hostService = hostService;
            _guestService = guestService;
            _administrationService = administrationService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                var userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    cachedUser = JsonSerializer.Deserialize<User>(userAsJson);
                    identity = SetupClaimsForUser(cachedUser);
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedUser);
            }

            var cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("You must enter an email address");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("You must enter a password");
            }

            var identity = new ClaimsIdentity();
            try
            {
                cachedUser = await _userService.ValidateUserAsync(email, password);
                if (await _administrationService.GetAdminByEmail(email) != null)
                {
                    isAdmin = true;
                }

                else if (await _guestService.GetGuestByEmail(email) != null)
                {
                    isGuest = true;
                }
                else if (await _hostService.GetHostByEmail(email) != null)
                {
                    isHost = true;
                }

                identity = SetupClaimsForUser(cachedUser);
                var userAsJson = JsonSerializer.Serialize(cachedUser);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", userAsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }
        
        private  ClaimsIdentity SetupClaimsForUser(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim("lastName", user.LastName));
            claims.Add(new Claim("email", user.Email));
            claims.Add(new Claim("phoneNumber", user.PhoneNumber));
            if (isAdmin)
            {
                Console.WriteLine("Admin");
                claims.Add(new Claim("Role", "Admin"));
            }
            else if (isHost)
            {
                Console.WriteLine("Host");
                claims.Add(new Claim("Role", "Host"));
            }
            else if (isGuest)
            {
                Console.WriteLine("Guest");
                claims.Add(new Claim("Role", "Guest"));
            }
            var identity = new ClaimsIdentity(claims, "apiauth_type");
            string test = string.Join(",", identity.Claims);
            Console.WriteLine(test);
            return identity;
        }
        
        public void Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}