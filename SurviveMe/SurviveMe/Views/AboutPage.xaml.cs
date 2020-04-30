using SurviveMe.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurviveMe.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            FinishRegStack.IsVisible = showHelpStack();
        }

        private bool showHelpStack()
        {
            var doesExist = false;
            doesExist = Navigation.NavigationStack.Any(p => p is AppShell) ? true : false;
            return doesExist;
        }
    }
}