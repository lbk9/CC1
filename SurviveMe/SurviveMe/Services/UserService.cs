using SurviveMe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveMe.Services
{
    public class UserService : IUserService
    {
        FirebaseHelper helper = new FirebaseHelper();

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await helper.GetAllUsers();
            return allUsers;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await helper.GetUser(id);
            return user;
        }

        public async void StoreUser(User user)
        {
            await helper.AddUser(user);
        }
    }
}
