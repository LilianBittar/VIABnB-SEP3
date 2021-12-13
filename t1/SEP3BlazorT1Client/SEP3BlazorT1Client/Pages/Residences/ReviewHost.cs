using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.Residences
{
    public partial class ReviewHost
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IHostReviewService HostReviewService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public IGuestService GuestService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        [Parameter] public int Id { get; set; }

        private Host _host = new Host();
        private Guest _guest = new Guest();
        private List<Guest> _guests = new List<Guest>();
        private HostReview _hostReview;

        private bool _isLoading;
        private  bool dialogIsOpen = false;
        private double _rating = 0;
        private string _reviewText  = "";

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            _host = await HostService.GetHostByIdAsync(Id);
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            try
            {
                var guest = await GuestService.GetGuestByEmailAsync(user.Claims
                    .FirstOrDefault(c => c.Type.ToString() == "email")?.Value);
                _guest = guest;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            if (_host.HostReviews != null)
            {
                foreach (var item in _host.HostReviews)
                {
                    var g = await GuestService.GetGuestByIdAsync(item.GuestId);
                    _guests.Add(g);
                }
            }
            StateHasChanged();
            _isLoading = false;
        }
        
        private void OpenDialog()
        {
            dialogIsOpen = true;
        }
        private async void OkClick()
        {
             await CreateReview();
            dialogIsOpen = false;
        }

        private async Task CreateReview()
        {
            _hostReview = new HostReview()
            {
                CreatedDate = DateTime.Now,
                Rating = _rating,
                HostId = Id,
                GuestId = _guest.Id,
                Text = _reviewText
            };
             await HostReviewService.CreateHostReviewAsync(_hostReview);
        }

        private void ToBrowse()
        {
            NavigationManager.NavigateTo("residences");
        }
    }
}