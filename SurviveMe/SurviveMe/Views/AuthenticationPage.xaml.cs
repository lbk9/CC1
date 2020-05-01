using SurviveMe.Models;
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
    public partial class AuthenticationPage : ContentPage
    {
        public AuthenticationPage()
        {
            InitializeComponent();
        }

        private void OnRegistrationComplete(object sender, EventArgs e)
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = UserName.Text,
                Password = UserPassword.Text,
                PhoneNumber = UserPhoneNumber.Text,
                Email = UserEmail.Text,
                Address = new Address
                {
                    HouseNumber = int.Parse(UserHouseNumber.Text),
                    Postcode = UserPostCode.Text
                },
                EmergencyContact = new EmergencyContact
                {
                    EmailAddress = UserEmergencyEmail.Text,
                    Name = UserEmergencyName.Text,
                    PhoneNumber = UserEmergencyNumber.Text
                }
            };
            Application.Current.MainPage = new AppShell();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private void UpdatePasswordVisibility(object sender, EventArgs e)
        {
            UserPassword.IsPassword = UserPassword.IsPassword ? false : true;
        }
    }
}