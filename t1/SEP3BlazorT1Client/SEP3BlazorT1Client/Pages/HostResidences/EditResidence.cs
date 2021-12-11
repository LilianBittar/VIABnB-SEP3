using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        private Facility _newFacility = new Facility();
        private bool _isLoading;
        private bool _isEditable;
        private bool _snackBarIsOpen = false;
        private bool _dialogIsOpen = false;
        private string _ruleDescription;
        private int _ruleResidenceId;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _isLoading = true;
                _isEditable = true;
                _residence = await ResidenceService.GetResidenceByIdAsync(Id);
                _facilities = await FacilityService.GetAllFacilities();
                _rules = _residence.Rules;
                StateHasChanged();
                _isLoading = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void EditContent()
        {
            _isEditable = false;
        }

        private async Task DeleteResidence()
        {
            Console.WriteLine(JsonSerializer.Serialize(_residence));
            var residence = await ResidenceService.DeleteResidenceAsync(_residence);
            Console.WriteLine(JsonSerializer.Serialize(residence));
            if (residence != null)
            {
                NavigationManager.NavigateTo("HostResidences");
            }
            else
            {
                Console.WriteLine("Can't delete");
            }
        }

        private void AddRule()
        {
            var newRule = new Rule()
            {
                Description = _ruleDescription
            };
            if (!string.IsNullOrEmpty(newRule.Description) && _residence.Rules.All(rule => rule.Description != newRule.Description))
            {
                _residence.Rules.Add(newRule);
            }
            StateHasChanged();
        }

        private void DeleteRule(Rule delete)
        {
            _residence.Rules.Remove(delete);
        }
        private void AddFacility()
        {
            var updateFacility = _facilities.FirstOrDefault(facility => facility.Name == _newFacility.Name);
            if (updateFacility != null && !string.IsNullOrEmpty(_newFacility.Name) && _residence.Facilities.All(facility => facility.Name != updateFacility.Name))
            {
                _residence.Facilities.Add(new Facility(){Id = updateFacility.Id, Name = updateFacility.Name});
            }
            StateHasChanged();
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

        private void DialogIsOpen()
        {
            _dialogIsOpen = true;
        }

        private void OkClick()
        {
            _dialogIsOpen = false;
        }
    }
}