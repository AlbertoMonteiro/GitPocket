using Windows.Storage;

namespace GitPocket.Business
{
    public sealed class Authentication : IAuthentication
    {
        private const string EMAIL = "email";
        private const string PASSWORD = "password";
        private readonly ApplicationDataContainer roamingSettings;

        public Authentication()
        {
            roamingSettings = ApplicationData.Current.RoamingSettings; // how we should store the login data
        }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool IsAuthenticated { get; set; }

        /// <summary>
        ///     Tries to authenticate and save the email/password in roaming settings storage
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void Login(string email, string password)
        {
            Email = email;
            Password = password;

            // Log the user in then store the login data if successful

            roamingSettings.Values[EMAIL] = email;
            roamingSettings.Values[PASSWORD] = password;

            IsAuthenticated = true;
        }

        /// <summary>
        ///     Logout and clear the cache
        /// </summary>
        public void Logout()
        {
            roamingSettings.Values.Remove(EMAIL);
            roamingSettings.Values.Remove(PASSWORD);

            IsAuthenticated = false;
        }
    }
}
