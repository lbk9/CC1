using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SurviveMe.Models;
using SurviveMe.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SurviveMe.ViewModels
{
    public class DashboardPageViewModel : BindableBase
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

        public DashboardPageViewModel(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
            Title = "Welcome to CC1 Hussars";
            OpenHelpLinkCommand = new DelegateCommand(OpenHelpLink);
            OpenInfoLinkCommand = new DelegateCommand(OpenInfoLink);
            ToBookACallCommand = new DelegateCommand(ToBookACall);
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
            await _navigationService.NavigateAsync("BookACallPage");
        }
    }
}
