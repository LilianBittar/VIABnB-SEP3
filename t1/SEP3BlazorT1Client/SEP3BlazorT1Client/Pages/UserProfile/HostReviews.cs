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
        private Guest _guest = new Guest();

        private bool _isLoading;

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            _hostReviewList = await HostReviewService.GetAllHostReviewsByHostIdAsync(Id);
            StateHasChanged();
            _isLoading = false;
        }

        private async Task<Guest> GetGuestById(int guestId)
        {
            return await GuestService.GetGuestById(guestId);
        }
    }
}