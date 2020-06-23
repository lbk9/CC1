using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SurviveMe.Models;
using SurviveMe.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SurviveMe.ViewModels
{
    public class BookACallPageViewModel : BindableBase, IInitialize
    {
        // Dependencies
        private INavigationService _navigationService;
        private ICaseManagementService _caseManagementService;

        // Commands
        public DelegateCommand CallRequestedCommand { get; private set; }
        public DelegateCommand BackToDashboardCommand { get; private set; }

        // Properties
        private List<string> _callTimesList;
        public List<string> CallTimesList
        {
            get { return _callTimesList; }
            set { SetProperty(ref _callTimesList, value); }
        }

        private User _activeUser;
        public User ActiveUser
        {
            get { return _activeUser; }
            set { SetProperty(ref _activeUser, value); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            { 
                if(SetProperty(ref _phoneNumber, value))
                {
                    RaisePropertyChanged(PhoneNumber);
                }
            }
        }

        public BookACallPageViewModel(INavigationService navigationService, ICaseManagementService caseManagementService)
        {
            _navigationService = navigationService;
            _caseManagementService = caseManagementService;
            CallRequestedCommand = new DelegateCommand(CallRequested);
            BackToDashboardCommand = new DelegateCommand(BackToDashboard);
            CallTimesList = new List<string> { "Now - within the next five minutes", "Select a time" };
        }

        public void Initialize(INavigationParameters parameters)
        {
            var activeUser = parameters["activeUser"] as User;
            ActiveUser = activeUser;
            PhoneNumber = ActiveUser.PhoneNumber;
        }

        private async void CallRequested()
        {
            var caseToRaise = new UserCase
            {
                UserId = ActiveUser.Id,
                UserPhoneNumber = ActiveUser.PhoneNumber,
                UserName = ActiveUser.Name,
                BuddyId = Guid.NewGuid(),
                CallTime = DateTime.Now,
                CallTimeAsString = DateTime.Now.ToString(),
                SelectedIssues = new List<string> { },
            };
            _caseManagementService.RegisterCase(caseToRaise);
            //await _navigationService.NavigateAsync(NavigationConstants.DashboardAbsolutePath);
            await _navigationService.GoBackAsync();
        }

        private async void BackToDashboard()
        {
            //await _navigationService.NavigateAsync(NavigationConstants.DashboardAbsolutePath);
            await _navigationService.GoBackAsync();
        }
    }
}
