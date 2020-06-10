using SurviveMeCC1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveMeCC1.Services
{
   public class UserService : IUserService
    {
        private FirebaseHelper _firebaseHelper;
        public UserService(FirebaseHelper firebaseHelper)
        {
            _firebaseHelper = firebaseHelper;
        }

        public User ActiveUser { get; private set; }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _firebaseHelper.GetAllUsers();
            return allUsers;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _firebaseHelper.GetUser(id);
            return user;
        }

        public async void StoreUser(User user)
        {
            await _firebaseHelper.AddUser(user);
            ActiveUser = user;
        }
    }
}
