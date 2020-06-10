using SurviveMeCC1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveMeCC1.Services
{
    public interface IUserService
    {
        User ActiveUser { get; }
        void StoreUser(User user);
        Task<User> GetUser(Guid id);
        Task<List<User>> GetAllUsers();
    }
}
