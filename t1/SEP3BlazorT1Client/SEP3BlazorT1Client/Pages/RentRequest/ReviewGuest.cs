using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.RentRequest
{
    public partial class ReviewGuest
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IGuestReviewService GuestReviewService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public IGuestService GuestService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        [Parameter] public int Id { get; set; }

        private Host _host = new Host();
        private Guest _guest = new Guest();
        private GuestReview _guestReview = new GuestReview();

        private bool _isloading;
        private bool dialogIsOpen = false;
        private double _rating = 0;
        private string _reviewTest = "";

        protected override async Task OnInitializedAsync()
        {
            _isloading = true;
            _guest = await GuestService.GetGuestByIdAsync(Id);
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            try
            {
                var host = await HostService.GetHostByEmailAsync(user.Claims.FirstOrDefault(c => c.Type.ToString() == "email")
                    ?.Value);
                _host = host;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            StateHasChanged();
            _isloading = false;
        }

        private void OpenDialog()
        {
            dialogIsOpen = true;
        }

        private async void OkClick()
        {

            try
            {
                await CreateReview();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            dialogIsOpen = false;
        }

        private async Task CreateReview()
        {
            _guestReview = new GuestReview()
            {
                Rating = _rating,
                Text = _reviewTest,
                CreatedDate = DateTime.Now,
                GuestId = Id,
                HostId = _host.Id
            };
            await GuestReviewService.CreateGuestReviewAsync(_guestReview);
        }

        private void ToUserReview()
        {
            NavigationManager.NavigateTo("user");
        }
    }
}