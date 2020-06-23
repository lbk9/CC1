using SurviveMe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveMe.Services
{
   public class UserService : IUserService
    {
        private FirebaseHelper _firebaseHelper;
        public UserService(FirebaseHelper firebaseHelper)
        {
            _firebaseHelper = firebaseHelper;
        }

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
        }
    }
}
