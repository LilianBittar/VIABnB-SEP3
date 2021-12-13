using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.UserProfile
{
    public partial class HostReviews
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IHostReviewService HostReviewService { get; set; }
        [Inject] public IGuestService GuestService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        [Parameter] public int Id { get; set; }
        private IEnumerable<HostReview> _hostReviewList = new List<HostReview>();
        private List<Guest> _guestList = new List<Guest>();
        private string ErrorMessage = "";

        private bool _isLoading;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _isLoading = true;
                _hostReviewList = await HostReviewService.GetAllHostReviewsByHostIdAsync(Id);
                foreach (var item in _hostReviewList)
                {
                    var g =  await GuestService.GetGuestByIdAsync(item.GuestId);
                    _guestList.Add(g);
                }
                StateHasChanged();
                _isLoading = false;
            }
            catch (Exception e)
            {
                ErrorMessage = "";
                ErrorMessage = "Something went wrong, try refreshing the page";
            }
           
        }
    }
}