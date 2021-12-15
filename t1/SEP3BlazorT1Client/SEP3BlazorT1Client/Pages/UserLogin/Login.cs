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

        private string _email;
        private string _password;
        private string _errorMessage;
        private bool _loginAsHost;
        private string _txtType = "password";
        private string _iconType = MatIconNames.Visibility;
        private bool IsShow { get; set; } = true;

        private void ShowLoadingBar()   
        {
            IsShow = !IsShow;
        }

        private void ShowPassword()
        {
            if (_txtType == "password")
            {
                _txtType = "text";
                _iconType = MatIconNames.Visibility_off;
            }
            else
            {
                _txtType = "password";
                _iconType = MatIconNames.Visibility;
            }
        }

        private async Task PerformLogin()
        {
            _errorMessage = "";
            try
            {
                if (_loginAsHost)
                {
                    ShowLoadingBar();
                    await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(_email,
                        _password);
                    _password = "";
                    NavigationManager.NavigateTo("/HostResidences");
                }
                else
                {
                    ShowLoadingBar();
                    await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(_email,
                        _password);
                    _email = "";
                    _password = "";
                    NavigationManager.NavigateTo("/User");
                }
            }
            catch (Exception e)
            {
                ShowLoadingBar();
                _errorMessage = e.Message;
                Console.WriteLine(e.Message);
            }
        }
    }
}