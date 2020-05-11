using SurviveMe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveMe.Services
{
    public interface IUserService
    {
        void StoreUser(User user);
        Task<User> GetUser(Guid id);
        Task<List<User>> GetAllUsers();
    }
}
