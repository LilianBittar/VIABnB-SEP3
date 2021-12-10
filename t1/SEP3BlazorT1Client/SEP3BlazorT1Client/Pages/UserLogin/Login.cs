using System;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Authentication;
using SEP3BlazorT1Client.Data;

namespace SEP3BlazorT1Client.Pages.UserLogin
{
    public partial class Login
    {
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IGuestService GuestService { get; set; }

        private string email;
        private string password;
        private string ErrorMessage;
        private bool loginAsHost;
        private string TxtType = "password";
        private string IconType = MatIconNames.Visibility;
        private bool IsShow { get; set; } = true;

        private void ShowLoadingBar()   
        {
            IsShow = !IsShow;
        }

        public void ShowPassword()
        {
            if (this.TxtType == "password")
            {
                this.TxtType = "text";
                IconType = MatIconNames.Visibility_off;
            }
            else
            {
                this.TxtType = "password";
                IconType = MatIconNames.Visibility;
            }
        }

        private async Task PerformLogin()
        {
            ErrorMessage = "";
            try
            {
                if (loginAsHost)
                {
                    ShowLoadingBar();
                    await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(email,
                        password);
                    password = "";
                    NavigationManager.NavigateTo("/HostResidences");
                }
                else
                {
                    ShowLoadingBar();
                    await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(email,
                        password);
                    email = "";
                    password = "";
                    NavigationManager.NavigateTo("/User");
                }
            }
            catch (Exception e)
            {
                ShowLoadingBar();
                ErrorMessage = e.Message;
                Console.WriteLine(e.Message);
            }
        }
    }
}