using System;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Authentication;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.UserProfile
{
    public partial class MyProfile
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public IUserService UserService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        
        [Parameter] public int Id { get; set; }
        private Host _host = new Host();
        private User _user = new User();
        private string _newPassword;
        private bool _isLoading;
        private bool _isEditable;
        private bool _snackBarIsOpen = false;
        private string _errorMessage="";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _isEditable = true;
                _isLoading = true;
                _host = await HostService.GetHostByIdAsync(Id);
                StateHasChanged();
                _isLoading = false;
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
            catch (Exception e)
            {
                _errorMessage = "";
                _errorMessage = "Something went wrong.. try refreshing the page";
            }
           
        }
        private static void FilesReady()
        {
            Console.WriteLine("Not working for now");
        }

        private void EditContent()
        {
            _isEditable = false;
        }

        private async Task DeleteProfile()
        {
            var deletedUser = await UserService.DeleteUserAsync(_user);
            if (deletedUser != null)
            {
                ((CustomAuthenticationStateProvider) AuthStateProvider).Logout();
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Console.WriteLine("can't delete");
            }
        }
        
        private async Task UpdateUser()
        {
            await UserService.UpdateUserAsync(_user);
        }
        
        private async Task OpenConfirmFromService()
        {
            bool isReady;
            isReady = await MatDialogService.ConfirmAsync("Are you sure you want to update your profile?");
            if (isReady)
            {
                await UpdateUser();
                _snackBarIsOpen = true;
                StateHasChanged();
            }
        }

        private void ToUserView()
        {
            NavigationManager.NavigateTo("User");
        }
    }
}