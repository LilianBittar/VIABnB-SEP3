
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
        [Inject] public IHostService HostService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        [Parameter] public int Id { get; set; }
        private IEnumerable<GuestReview> _guestReviewList = new List<GuestReview>();
        private List<Host> _hostList = new List<Host>();
        
        private bool _isLoading;

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            _guestReviewList = await GuestReviewService.GetAllGuestReviewsByGuestIdAsync(Id);
            foreach (var item in _guestReviewList)
            {
                var h = await HostService.GetHostById(item.HostId);
            }
            StateHasChanged();
            _isLoading = false;
        }
    }
}