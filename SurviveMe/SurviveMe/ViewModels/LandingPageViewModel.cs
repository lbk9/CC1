using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace SurviveMe.ViewModels
{
    public class LandingPageViewModel : BindableBase
    {
        // Dependencies
        private INavigationService _navigationService;

        // Commands
        public DelegateCommand ToAuthenticationCommand { get; private set; }
        public DelegateCommand ToHelpCommand { get; private set; }

        public LandingPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ToAuthenticationCommand = new DelegateCommand(ToAuthentication);
            ToHelpCommand = new DelegateCommand(ToHelp);
        }

        private async void ToAuthentication()
        {
            var result = await _navigationService.NavigateAsync(NavigationConstants.AuthenticationRelativePath);
        }

        private async void ToHelp()
        {
            await _navigationService.NavigateAsync(NavigationConstants.HelpRelativePath);
        }
    }
}
