using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SurviveMe.ViewModels
{
    public class BookACallPageViewModel : BindableBase
    {
        // Dependencies
        private INavigationService _navigationService;

        // Commands
        public DelegateCommand CallRequestedCommand { get; private set; }

        // Properties
        private List<string> _callTimesList;
        public List<string> CallTimesList
        {
            get { return _callTimesList; }
            set { SetProperty(ref _callTimesList, value); }
        }

        public BookACallPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CallRequestedCommand = new DelegateCommand(CallRequested);
            CallTimesList = new List<string> { "Now - within the next five minutes", "Select a time" };
        }

        private async void CallRequested()
        {
            await _navigationService.NavigateAsync("app:///NavigationPage/DashboardPage");
        }
    }
}
