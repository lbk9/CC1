using SurviveMe.Models;
using SurviveMe.Services;
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

        private async void OnRegistrationComplete(object sender, EventArgs e)
        {
            UserService userService = new UserService();
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

            // persist this model to DB using UserService
            userService.StoreUser(user);
            await DisplayAlert("Registration Complete", "Thank you for providing your details to us", "Ok");
            Application.Current.MainPage = new AppShell();
        }

        private void UpdatePasswordVisibility(object sender, EventArgs e)
        {
            UserPassword.IsPassword = UserPassword.IsPassword ? false : true;
        }
    }
}