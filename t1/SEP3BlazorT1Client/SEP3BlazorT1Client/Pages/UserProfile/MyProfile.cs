using System;
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
        [Inject] public IUserService UserService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        [Parameter] public int Id { get; set; }
        private Host _host = new Host();
        private User _user = new User();
        private string newPassword;
        private bool isLoading;
        private bool isEditable;
        bool snackBarIsOpen = false;

        protected override async Task OnInitializedAsync()
        {
            isEditable = true;
            isLoading = true;
            _host = await HostService.GetHostById(Id);
            StateHasChanged();
            isLoading = false;
            _user = new User()
            {
                Id = _host.Id,
                FirstName = _host.FirstName,
                LastName = _host.LastName,
                Email = _host.Email,
                Password = _host.Password,
                PhoneNumber = _host.PhoneNumber,
                ProfileImageUrl = _host.ProfileImageUrl
            };
        }
        private void FilesReady()
        {
            throw new System.NotImplementedException();
        }

        private void EditContent()
        {
            isEditable = false;
        }

        private async Task DeleteProfile()
        {
            await UserService.DeleteUserAsync(_user);
            NavigationManager.NavigateTo("Login");
        }
        
        private async Task<User> UpdateUser()
        {
            return await UserService.UpdateUserAsync(_user);
        }
        
        private async Task OpenConfirmFromService()
        {
            bool isReady;
            isReady = await MatDialogService.ConfirmAsync("Are you sure you want to update your profile?");
            if (isReady)
            {
                UpdateUser();
                snackBarIsOpen = true;
                StateHasChanged();
            }
        }

        private void ToUserView()
        {
            NavigationManager.NavigateTo("User");
        }
    }
}