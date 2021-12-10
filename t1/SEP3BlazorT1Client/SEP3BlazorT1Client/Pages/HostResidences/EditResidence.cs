using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.HostResidences
{
    public partial class EditResidence
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IResidenceService ResidenceService { get; set; }
        [Inject] public IRuleService RuleService { get; set; }
        [Inject] public IFacilityService FacilityService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        [Parameter] public int Id { get; set; }

        private Residence _residence = new Residence();
        private Host _host = new Host();
        private IEnumerable<Rule> _rules = new List<Rule>();
        private IEnumerable<Facility> _facilities = new List<Facility>();
        private Facility _matSelectItemType;
        private bool _isLoading;
        private bool _isEditable;
        private bool _snackBarIsOpen = false;

        protected override async Task OnInitializedAsync()
        {
            _isEditable = true;
            _isLoading = true;
            _residence = await ResidenceService.GetResidenceByIdAsync(Id);
            _facilities = await FacilityService.GetAllFacilities();
            _rules = _residence.Rules;
            StateHasChanged();
            _isLoading = false;
        }

        private void EditContent()
        {
            _isEditable = false;
        }

        private async Task DeleteResidence()
        {
            var deleteResidence = await ResidenceService.DeleteResidenceAsync(_residence);
            if (deleteResidence != null)
            {
                NavigationManager.NavigateTo("HostResidences");
            }
            else
            {
                Console.WriteLine("Can't delete");
            }
        }

        private async Task<Residence> UpdateResidence()
        {
            return await ResidenceService.UpdateResidenceAsync(_residence);
        }

        private async Task OpenConfirmUpdateFromService()
        {
            bool isReady;
            isReady = await MatDialogService.ConfirmAsync("Are you sure you want to update your residence?");
            if (isReady)
            {
                UpdateResidence();
                _snackBarIsOpen = true;
                StateHasChanged();
            }
        }
        
        private async Task OpenConfirmDeleteFromService()
        {
            bool isReady;
            isReady = await MatDialogService.ConfirmAsync("Are you sure you want to delete your residence?");
            if (isReady)
            {
                UpdateResidence();
                _snackBarIsOpen = true;
                StateHasChanged();
            }
        }

        private void ToHostResidence()
        {
            NavigationManager.NavigateTo("HostResidences");
        }
    }
}