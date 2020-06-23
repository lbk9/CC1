using Firebase.Database;
using Firebase.Database.Query;
using SurviveMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurviveMe.Services
{
    public class FirebaseHelper
    {
        readonly FirebaseClient firebase = new FirebaseClient("https://surviveme-92581.firebaseio.com/");

        public async Task AddUser(User user)
        {
            await firebase.Child("Users")
                .PostAsync(user);
        }

        public async Task<User> GetUser(Guid id)
        {
            var allUsers = await GetAllUsers();
            return allUsers.Where(user => user.Id == id).FirstOrDefault();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return (await firebase.Child("Users")
                .OnceAsync<User>()).Select(user => new User
                {
                    Id = user.Object.Id,
                    Name = user.Object.Name,
                    Email = user.Object.Email,
                    Password = user.Object.Password,
                    PhoneNumber = user.Object.PhoneNumber,
                    Address = user.Object.Address,
                    EmergencyContact = user.Object.EmergencyContact,
                }).ToList();
        }

        public async Task AddCase(UserCase userCase)
        {
            await firebase.Child("Cases")
                .PostAsync(userCase);
        }
    }
}
