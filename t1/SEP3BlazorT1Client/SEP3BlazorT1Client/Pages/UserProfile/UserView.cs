using System;
using System.Collections.Generic;
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
        [Inject] public IHostService HostService { get; set; }
        [Inject] public IGuestService GuestService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        private Host _host;
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
            _host = await HostService.GetHostByEmail((user.Claims.FirstOrDefault(c => c.Type.ToString() == "email").Value));

            if (!user.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        private void ToHostResidence()
        {
            NavigationManager.NavigateTo("HostResidences");
        }

        private void ToMyProfile()
        {
            NavigationManager.NavigateTo("MyProfile");
        }

        private void ToMyReviews()
        {
            NavigationManager.NavigateTo("MyReviews");
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