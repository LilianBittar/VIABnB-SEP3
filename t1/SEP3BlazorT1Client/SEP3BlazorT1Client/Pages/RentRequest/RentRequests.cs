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
    public partial class RentRequests
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IRentalService RentalService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private IEnumerable<Models.RentRequest> _rentRequestList = new List<Models.RentRequest>();
        protected override async Task OnInitializedAsync()
        {
            _rentRequestList = await RentalService.GetAllNotAnsweredRentRequestAsync();
        }

        private void ViewGuestReviews(int id)
        {
            NavigationManager.NavigateTo($"GuestReviews/{id}");
        }

        private async Task ApproveRequest(int requestId)
        {
            var approvedRequest = _rentRequestList.First(r => r.Id == requestId);
            approvedRequest.Status = RentRequestStatus.APPROVED;
            await RentalService.UpdateRentRequestAsync(approvedRequest);
        }

        private async Task RejectRequest(int requestId)
        {
            var rejectedRequest = _rentRequestList.First(r => r.Id == requestId);
            rejectedRequest.Status = RentRequestStatus.NOTAPPROVED;
            await RentalService.UpdateRentRequestAsync(rejectedRequest);
        }
    }
}