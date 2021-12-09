using System;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.UserProfile
{
    public partial class UserView
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IUserService UserService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        private User _user;
        private bool _dialogIsOpen = false;
        private string _errorLabel = "";
        
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            Console.WriteLine("\nClaims:");
            foreach (var claim in user.Claims)
            {
                Console.WriteLine($"{claim.Type.ToString()} {claim.Value}");
            }

            try
            {
                _user = await UserService.GetUserByEmailAsync((user.Claims.FirstOrDefault(c => c.Type.ToString() == "email").Value));
            }
            catch (Exception e)
            {
                _errorLabel = e.Message;
            }

            if (!user.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        private void ToHostResidence()
        {
            NavigationManager.NavigateTo("HostResidences");
        }

        private void ToMyProfile(int id)
        {
            NavigationManager.NavigateTo($"MyProfile/{id}");
        }

        private void ToHostReviews(int id)
        {
            NavigationManager.NavigateTo($"HostReviews/{id}");
        }
        private void ToGuestReviews(int id)
        {
            NavigationManager.NavigateTo($"GuestReviews/{id}");
        }

        private void ToMyMail()
        {
            
        }

        private void ToRegisterResidence()
        {
            NavigationManager.NavigateTo("registerresidence");
        }

        private void ToRentRequest()
        {
            NavigationManager.NavigateTo("RentRequests");
        }
    }
}