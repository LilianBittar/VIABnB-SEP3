using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.AdminView
{
    public partial class UserRequests
    {

        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public IGuestService GuestService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        private IEnumerable<Guest> _guestRequestList = new List<Guest>();
        private IEnumerable<Host> _hostRequestList = new List<Host>();
        private string ErrorMessage="";
        
        protected override async Task OnInitializedAsync()
        {
            try
            {
                _hostRequestList = await HostService.GetAllNotApprovedHostsAsync();
                _guestRequestList = await GuestService.GetAllNotApprovedGuests();
                StateHasChanged();
            }
            catch (Exception e)
            {
                ErrorMessage = "";
                ErrorMessage = "Something went wrong.. try refreshing the page";
            }
        }
        
        private async Task ApproveHost(int hostId)
        {
            var approvedHost = _hostRequestList.First(host => host.Id == hostId);
            approvedHost.IsApprovedHost = true;
            await HostService.UpdateHostStatusAsync(approvedHost);
            StateHasChanged();
        }
        
        private async Task RejectHost(int hostId)
        {
            var rejectedHost = _hostRequestList.First(host => host.Id == hostId);
            rejectedHost.IsApprovedHost = false;
            await HostService.UpdateHostStatusAsync(rejectedHost);
            StateHasChanged();
        }

        private async Task ApproveGuest(int guestId)
        {
            var approvedGuest = _guestRequestList.First(guest => guest.Id == guestId);
            approvedGuest.IsApprovedGuest = true;
            await GuestService.UpdateGuestStatusAsync(approvedGuest);
            StateHasChanged();
        }
        private async Task RejectGuest(int guestId)
        {
            var rejectedGuest = _guestRequestList.First(guest => guest.Id == guestId);
            rejectedGuest.IsApprovedGuest = false;
            await GuestService.UpdateGuestStatusAsync(rejectedGuest);
            StateHasChanged();
        }
    }
}