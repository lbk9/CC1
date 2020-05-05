using SurviveMe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveMe.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
           
        }

        public User ActiveUser { get; private set; }

        public void SetActiveUer(User user)
        {
            ActiveUser = user;
        }
    }
}
