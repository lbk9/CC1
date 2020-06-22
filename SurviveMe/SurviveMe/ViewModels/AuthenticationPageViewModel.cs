using DryIoc;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SurviveMe.Models;
using SurviveMe.Services;
using System;

namespace SurviveMe.ViewModels
{
    public class AuthenticationPageViewModel : BindableBase
    {
        // Dependencies
        private INavigationService _navigationService;
        private IUserService _userService;

        // Commands
        public DelegateCommand OnRegistrationCompletedCommand { get; private set; }

        // Properties
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public AuthenticationPageViewModel(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
            Title = "Registration";
            OnRegistrationCompletedCommand = new DelegateCommand(OnRegistrationCompleted);
        }

        private async void OnRegistrationCompleted()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "sampleactive",
                Password = "sample",
                PhoneNumber = "sample",
                Email = "sample",
                Address = new Address
                {
                    HouseNumber = int.Parse("123"),
                    Postcode = "sample"
                },
                EmergencyContact = new EmergencyContact
                {
                    EmailAddress = "sample",
                    Name = "sample",
                    PhoneNumber = "sample"
                }
            };

            _userService.StoreUser(user);
            // Pass User model as navparams
            await _navigationService.NavigateAsync("DashboardPage");
        }
    }
}
