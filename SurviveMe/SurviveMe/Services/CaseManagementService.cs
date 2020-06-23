using SurviveMe.Models;

namespace SurviveMe.Services
{
    public class CaseManagementService : ICaseManagementService
    {
        private FirebaseHelper _firebaseHelper;

        public CaseManagementService(FirebaseHelper firebaseHelper)
        {
            _firebaseHelper = firebaseHelper;
        }

        public async void RegisterCase(UserCase userCase)
        {
            await _firebaseHelper.AddCase(userCase);
        }
    }
}
