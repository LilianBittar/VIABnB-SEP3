using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.UserProfile
{
    public partial class MyProfile
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public IGuestService GuestService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        [Parameter] public int Id { get; set; }
        private Host _host = new Host();
        private bool isLoading;

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;
            _host = await HostService.GetHostById(Id);
            StateHasChanged();
            isLoading = false;
        }
        private void FilesReady()
        {
            throw new System.NotImplementedException();
        }
    }
}