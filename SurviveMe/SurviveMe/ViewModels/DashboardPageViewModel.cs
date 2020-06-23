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
    public class DashboardPageViewModel : BindableBase, INavigationAware
    {
        //Dependencies
        private INavigationService _navigationService;
        private IUserService _userService;

        // Commands
        public DelegateCommand OpenHelpLinkCommand { get; private set; }
        public DelegateCommand OpenInfoLinkCommand { get; private set; }
        public DelegateCommand ToBookACallCommand { get; private set; }

        // Properties
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private User _activeUser;
        public User ActiveUser
        {
            get { return _activeUser; }
            set { SetProperty(ref _activeUser, value); }
        }

        public DashboardPageViewModel(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
            Title = "Welcome to CC1 Hussars";
            OpenHelpLinkCommand = new DelegateCommand(OpenHelpLink);
            OpenInfoLinkCommand = new DelegateCommand(OpenInfoLink);
            ToBookACallCommand = new DelegateCommand(ToBookACall);
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("userModel"))
            {
                var activeUser = parameters["userModel"] as User;
                ActiveUser = activeUser;
            }
        }

        private async void OpenHelpLink()
        {
            await Browser.OpenAsync("https://www.samaritans.org/scotland/how-we-can-help/if-youre-worried-about-someone-else/", BrowserLaunchMode.SystemPreferred);
        }

        private async void OpenInfoLink()
        {
            await Browser.OpenAsync("https://www.veteransgateway.org.uk/local-support/", BrowserLaunchMode.SystemPreferred);
        }

        private async void ToBookACall()
        {
            var navParams = new NavigationParameters
            {
                { "activeUser", ActiveUser }
            };
            await _navigationService.NavigateAsync(NavigationConstants.BookACallRelativePath, navParams);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
