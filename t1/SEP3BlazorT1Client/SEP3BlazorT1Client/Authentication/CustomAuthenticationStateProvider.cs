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

        private readonly IJSRuntime _jsRuntime;
        private readonly IUserService _userService;
        private readonly IHostService _hostService;
        private readonly IGuestService _guestService;
        private readonly IAdministrationService _administrationService;

        private User _cachedUser;

        private bool _isAdmin = false;
        private bool _isHost = false;
        private bool _isGuest = false;
        private bool _isApprovedHost = false;
        private bool _isApprovedGuest = false;
        
        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService, IHostService hostService, IGuestService guestService, IAdministrationService administrationService)
        {
            this._jsRuntime = jsRuntime;
            _userService = userService;
            _hostService = hostService;
            _guestService = guestService;
            _administrationService = administrationService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            Console.WriteLine($"{this} {_isAdmin} {_isGuest} {_isHost}");
            var identity = new ClaimsIdentity();
            if (_cachedUser == null)
            {
                var userAsJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    _cachedUser = JsonSerializer.Deserialize<User>(userAsJson);
                    await ValidateLogin(_cachedUser.Email, _cachedUser.Password);
                    identity = SetupClaimsForUser(_cachedUser);
                }
            }
            else
            {
                identity = SetupClaimsForUser(_cachedUser);
            }

            var cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }
        /// <summary>
        /// Validate the User's login.
        /// Based on the returned User type, one of the three boolean is set to true.
        /// If A host is returned the _isHost is set to true.  If that Host is an approved host then set the boolean _isApprovedHost to true
        /// If A guest is returned the _isGuest is set to true. If that Guest is an approved guest then set the boolean _isApprovedGust to true
        /// If An admin is returned the _isAdmin is set to true. If that Admin is an approved admin then set the boolean _isApprovedAdmin to true
        /// </summary>
        /// <param name="email">The given User's e-mail</param>
        /// <param name="password">The given user's password</param>
        /// <exception cref="ArgumentException">If the User's e-mail is null or empty string</exception>
        /// <exception cref="ArgumentException">If the User's password is null or empty password</exception>
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
                _cachedUser = await _userService.ValidateUserAsync(email, password);
                var _guest = await _guestService.GetGuestByEmailAsync(email);
                var _host = await _hostService.GetHostByEmailAsync(email);
                if (await _administrationService.GetAdminByEmailAsync(email) != null)
                {
                    _isAdmin = true;
                }

                else if (_host != null)
                {
                    if (_host.IsApprovedHost)
                    {
                        _isApprovedHost = true;
                    }
                    _isHost = true;
                    if (_guest != null)
                    {
                        if (_guest.IsApprovedGuest)
                        {
                            _isApprovedGuest = true; 
                        }
                        _isGuest = true; 
                    }
                }

                identity = SetupClaimsForUser(_cachedUser);
                var userAsJson = JsonSerializer.Serialize(_cachedUser);
                await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", userAsJson);
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
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim("lastName", user.LastName));
            claims.Add(new Claim("email", user.Email));
            claims.Add(new Claim("phoneNumber", user.PhoneNumber));
            claims.Add(new Claim("Id", user.Id.ToString()));
            if (_isAdmin)
            {
                Console.WriteLine("Admin");
                claims.Add(new Claim("Approved", "Host"));
                claims.Add(new Claim("Approved", "Guest"));
                claims.Add(new Claim("Role", "Admin"));
            }
            else if (_isHost)
            {
                if (_isApprovedHost)
                {
                    claims.Add(new Claim("Approved", "Host"));
                }
                Console.WriteLine("Host");
                claims.Add(new Claim("Role", "Host"));
                if (_isGuest)
                {
                    claims.Add(new Claim("Approved", "Guest"));
                    if (_isApprovedGuest)
                    {
                        claims.Add(new Claim("Approved", "Guest"));
                    }
                }
                
            }
            var identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        
        public void Logout()
        {
            _cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}