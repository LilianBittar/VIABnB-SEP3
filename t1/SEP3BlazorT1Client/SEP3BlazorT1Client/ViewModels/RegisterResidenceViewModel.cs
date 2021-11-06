using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Data.Impl;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.ViewModels
{
    //Using MVVM pattern, such that unit test can be written more easily 
    public class RegisterResidenceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IResidenceService _residenceService;
        private Residence _residenceToBeAdded = new Residence(){ Address = new Address(), Facilities = new List<Facility>(), Rules = new List<Rule>()};
    private IList<Facility> _allFacilities = new List<Facility>() {new Facility() {Name = "Wifi"}};
        private IList<string> _allResidenceTypes; 
        public Residence ResidenceToBeAdded
         {
            get => _residenceToBeAdded; 
            set 
            {
                _residenceToBeAdded = value; OnPropertyChanged();
            }
              
         }

        public IList<string> ResidenceTypes
        {
            get => _allResidenceTypes; 
            private set{
                _allResidenceTypes = value; 
            }
        }
        
        public IList<Facility> AllFacilities
        {
            get => _allFacilities;

            set
            {
                _allFacilities = value; OnPropertyChanged(); 
            }
        }

    /// <summary>
    /// Fires event everytime an property changes value. 
    /// </summary>
    /// <param name="propertyName">Name of the property that triggered the event</param>
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
        
        public RegisterResidenceViewModel(IResidenceService residenceService)
        {
            // constructor injection
            _residenceService = residenceService; 
        }

        public void AddNewRule(Rule rule)
        {
            if (!string.IsNullOrEmpty(rule.Description))
            {
                ResidenceToBeAdded.Rules.Add(rule); 
            }
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("NewRuleAdded"));
        } 


        public void AddNewFacility(Facility facility)
        {
            if (!string.IsNullOrEmpty(facility.Name))
            {
                ResidenceToBeAdded.Facilities.Add(facility); 
            }
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("NewFacilityAdded"));
        }

        public async Task RegisterResidenceAsync()
        {
            await _residenceService.CreateResidenceAsync(ResidenceToBeAdded);
        }
        
        
    }
}