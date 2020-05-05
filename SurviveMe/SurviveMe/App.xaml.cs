using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SurviveMe.Services;
using SurviveMe.Views;

namespace SurviveMe
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LandingPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
