using SurviveMe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveMe.Services
{
    public interface IUserService
    {
        User ActiveUser { get; }
        void SetActiveUer(User user);
    }
}
