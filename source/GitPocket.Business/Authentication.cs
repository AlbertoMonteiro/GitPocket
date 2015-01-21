using System.Threading.Tasks;
using Octokit;
using Octokit.Internal;
using Windows.Storage;

namespace GitPocket.Business
{
    public sealed class Authentication : IAuthentication
    {
        private const string EMAIL = "email";
        private const string PASSWORD = "password";
        private readonly ApplicationDataContainer roamingSettings;
        private readonly ProductHeaderValue productInformation;

        public Authentication(ProductHeaderValue productInformation)
        {
            this.productInformation = productInformation;
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
        public async Task<IGitHubClient> Login(string email, string password)
        {
            Email = email;
            Password = password;

            // Log the user in then store the login data if successful
            var connection = new Connection(productInformation, new InMemoryCredentialStore(new Credentials(email, password)));
            var gitHubClient = new GitHubClient(connection);
            await gitHubClient.User.Current();

            roamingSettings.Values[EMAIL] = email;
            roamingSettings.Values[PASSWORD] = password;

            IsAuthenticated = true;
            return gitHubClient;
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
