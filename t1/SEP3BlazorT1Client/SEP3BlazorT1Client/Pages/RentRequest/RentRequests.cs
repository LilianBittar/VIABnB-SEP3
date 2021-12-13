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
    public partial class RentRequests
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IRentalService RentalService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private string ErrorMessage="";

        private IEnumerable<Models.RentRequest> _activeRentRequestList;
        private IEnumerable<Models.RentRequest> _oldRentRequestList = new List<Models.RentRequest>();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                _activeRentRequestList = await RentalService.GetAllNotAnsweredRentRequestAsync();
                _oldRentRequestList = await RentalService.GetAllRentRequestsAsync();
            }
            catch (Exception e)
            {
                ErrorMessage = "";
                ErrorMessage = "Something went wrong.. try refreshing the page";
            }
           
        }

        private void ViewGuestReviews(int id)
        {
            NavigationManager.NavigateTo($"Reviews/{id}");
        }

        private async Task ApproveRequest(int requestId)
        {
            var approvedRequest = _activeRentRequestList.First(r => r.Id == requestId);
            approvedRequest.Status = RentRequestStatus.APPROVED;
            await RentalService.UpdateRentRequestAsync(approvedRequest);
        }

        private async Task RejectRequest(int requestId)
        {
            var rejectedRequest = _activeRentRequestList.First(r => r.Id == requestId);
            rejectedRequest.Status = RentRequestStatus.NOTAPPROVED;
            await RentalService.UpdateRentRequestAsync(rejectedRequest);
        }
    }
}