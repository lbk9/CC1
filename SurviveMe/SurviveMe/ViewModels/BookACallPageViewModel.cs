using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveMe.ViewModels
{
    public class BookACallPageViewModel : BindableBase
    {
        // Dependencies
        private INavigationService _navigationService;

        // Commands
        public DelegateCommand CompleteBookingCommand;

        public BookACallPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CompleteBookingCommand = new DelegateCommand(CompleteBooking);
        }

        private async void CompleteBooking()
        {
            await _navigationService.NavigateAsync("DashboardPage");
        }
    }
}
