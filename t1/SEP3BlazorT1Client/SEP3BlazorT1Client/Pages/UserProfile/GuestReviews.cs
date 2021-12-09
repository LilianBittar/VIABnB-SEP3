
using System.Collections.Generic;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.UserProfile
{
    public partial class GuestReviews
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IGuestReviewService GuestReviewService { get; set; }
        [Inject] public IGuestService GuestService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        [Parameter] public int Id { get; set; }
        private IEnumerable<GuestReview> _guestReviewList = new List<GuestReview>();

        private Host _host = new Host();

        private bool _isLoading;

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            _guestReviewList = await GuestReviewService.GetAllGuestReviewsByGuestIdAsync(Id);
            StateHasChanged();
            _isLoading = false;
        }
    }
}