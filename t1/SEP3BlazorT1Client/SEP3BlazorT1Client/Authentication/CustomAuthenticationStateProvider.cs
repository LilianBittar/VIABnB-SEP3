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
        private readonly IAdministrationService _administrationService;

        private User cachedUser;
        /*private Host cachedHost;
        private Guest cachedGuest;
        private Administrator cachedAdmin;*/

        private bool isAdmin = false;
        private bool isHost = false;
        private bool isGuest = false;
        /*
         * Use booleans here to keep track of if the user is admin, guest, host
         */
        

        // TODO: REWRITE THIS TO A USER. CLAIMS DOESN'T WORK CORRECTLY RIGHT NOW :/
        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IHostService hostService, IGuestService guestService, IAdministrationService administrationService)
        {
            this.jsRuntime = jsRuntime;
            _hostService = hostService;
            _guestService = guestService;
            _administrationService = administrationService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                Console.WriteLine("We are here-------------------------------------------------------------");
                var userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    cachedUser = JsonSerializer.Deserialize<User>(userAsJson);
                    identity = SetupClaimsForUser(cachedUser);
                Console.WriteLine(JsonSerializer.Serialize(identity.Claims));
                }
            }
            else
            {
                Console.WriteLine("We are here-------------------------------------------------------------djhsakdhqkwjekqw");
                identity = SetupClaimsForUser(cachedUser);
                Console.WriteLine(JsonSerializer.Serialize(identity.Claims));
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
            try
            {
                var admin = await _administrationService.GetAdminByEmail(email);
                var host = await _hostService.GetHostByEmail(email);
                var guest = await _guestService.GetGuestByEmail(email);
                if (admin != null)
                {
                    cachedUser = await _administrationService.ValidateAdmin(email, password);
                    Console.WriteLine("IS ADMIN......................");
                    isAdmin = true;
                }

                if (host != null)
                {
                    cachedUser = await _hostService.ValidateHostAsync(email, password);
                    Console.WriteLine("IS HOST......................");
                    isHost = true;
                }
                
                if (guest != null)
                {
                    cachedUser = await _guestService.ValidateGuestAsync(email, password);
                    Console.WriteLine("IS GUEST......................");
                    isGuest = true;
                }

                if (cachedUser == null)
                {
                    throw new Exception("Email or password are incorrect");
                } 
                
                SetupClaimsForUser(cachedUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private  ClaimsIdentity SetupClaimsForUser(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim("LastName", user.FirstName));
            claims.Add(new Claim("Email", user.Email));
            claims.Add(new Claim("Password", user.Password));
            claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
            claims.Add(new Claim("Id", user.Id.ToString()));
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
            
            else if (isHost && isGuest)
            {
                Console.WriteLine("Guest");
                claims.Add(new Claim("Role", "Guest"));
            }
            var identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        
        public void Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        /*public async Task ValidateLoginAsAdmin(string email, string password)
        {
            //When validating the user, try to fetch an guest and user and admin and then set bools. 
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("You must enter an email address");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("You must enter a password");
            }
            Console.WriteLine("Validating Admin Login");
            ClaimsIdentity identity = new();
            try
            {
                var admin = await _administrationService.ValidateAdmin(email, password);
                
                if (admin == null)
                {
                    throw new Exception("Email or password are incorrect");
                }

                identity = SetupClaimsForAdmin(admin);
                var adminAsJson = JsonSerializer.Serialize(admin);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", adminAsJson);
                cachedAdmin = admin;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
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

        public async Task ValidateLoginAsGuest(string email,string password)
        {
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            if (string.IsNullOrEmpty(email.ToString())) throw new Exception("Enter email");
            
            Console.WriteLine("Validating log in as a guest.");
                
            ClaimsIdentity identity = new();
            try
            {
                Console.WriteLine("1");
                Console.WriteLine(email);
                Console.WriteLine(password);
                Guest user = await _guestService.ValidateGuestAsync(email, password);
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

        private static ClaimsIdentity SetUpClaimsForUser(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim("LastName", user.FirstName));
            claims.Add(new Claim("Email", user.Email));
            claims.Add(new Claim("Password", user.Password));
            claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
            claims.Add(new Claim("Id", user.Id.ToString()));
            var identity = new ClaimsIdentity(claims, "apiauth_type");
        }

        private ClaimsIdentity SetupClaimsForAdmin(Administrator administrator)
        {   
            // Use booleans to check what the claims should be 
            //if (host!= null)  claims.Add(new Claim("Role", "Admin"));
            // if (guest != null) claims.Add(new Claim("Role", "Guest"));
            // if (admin != null)  claims.Add(new Claim("Role", "Admin"));
            // if (host.isApprovedHost) claims.Add(new Claim("IsApprovedHost", "True"));
            // etc...
            
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, administrator.FirstName));
            claims.Add(new Claim("LastName", administrator.FirstName));
            claims.Add(new Claim("Email", administrator.Email));
            claims.Add(new Claim("Password", administrator.Password));
            claims.Add(new Claim("PhoneNumber", administrator.PhoneNumber));
            claims.Add(new Claim("Id", administrator.Id.ToString()));
            claims.Add(new Claim("Role", "Admin"));
            var identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
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
            claims.Add(new Claim("Role", "Host"));
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
            claims.Add(new Claim("Role", "Guest"));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }*/
    }
}