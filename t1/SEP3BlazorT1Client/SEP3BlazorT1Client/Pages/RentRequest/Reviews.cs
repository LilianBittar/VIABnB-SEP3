using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.RentRequest
{
    public partial class Reviews
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public IGuestReviewService GuestReviewService { get; set; }
        private string ErrorMessage="";
        private IEnumerable<GuestReview> _guestReviews = new List<GuestReview>();
        
        [Parameter]
        public int Id { get; set; }
        private List<Host> _hosts = new List<Host>();
        private Guest _guest = new Guest();


        
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Console.WriteLine(JsonSerializer.Serialize(await GuestReviewService.GetAllGuestReviewsByGuestIdAsync(Id)));
                _guestReviews = await GuestReviewService.GetAllGuestReviewsByGuestIdAsync(Id);
                if (_guest.GuestReviews != null)
                {
                    foreach (var item in _guestReviews)
                    {
                        var h = await HostService.GetHostByIdAsync(item.HostId);
                        _hosts.Add(h);
                    }
                }
            }
            catch (Exception e)
            {
                ErrorMessage = "";
                ErrorMessage = "Something went wrong.. try refreshing the page";
            }
            
        }

        private void ToReviewGuest(int id)
        {
            NavigationManager.NavigateTo($"ReviewGuest/{id}");
        }
    }
}