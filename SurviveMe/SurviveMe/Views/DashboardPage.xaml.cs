using SurviveMe.Models;
using SurviveMe.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SurviveMe.Views
{
    [DesignTimeVisible(false)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void TalkToVeteranClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookACallPage());
        }

        private async void InfoClicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.veteransgateway.org.uk/local-support/", BrowserLaunchMode.SystemPreferred);
        }

        private async void HelpClicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.samaritans.org/scotland/how-we-can-help/if-youre-worried-about-someone-else/", BrowserLaunchMode.SystemPreferred);
        }
    }
}