using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurviveMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookACallPage : ContentPage
    {
        public BookACallPage()
        {
            InitializeComponent();
        }

        private async void BookCallClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Buddy call booked", "Sit tight, we'll be with you within five minutes", "Finish");
            await Navigation.PopToRootAsync();
        }
    }
}