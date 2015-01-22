using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Octokit;
using Windows.Storage;

namespace GitPocket.Business.Test
{
    [TestClass]
    public class AuthenticationTest
    {
        private Authentication auth;
        private const string EMAIL = "mail@mail.com";
        private const string PASSWORD = "123456";

        [TestInitialize]
        public void SetUp()
        {
            /*IConnection connection = new MockConnection();
            IGitHubClient client = new MockGitHubClient();*/
            auth = new Authentication(new ProductHeaderValue("GitPocket"));
        }

        [TestMethod]
        public async Task WhenUserLoginInHeShouldBeAuthenticated()
        {
            await auth.Login(EMAIL, PASSWORD);
            
            Assert.IsTrue(auth.IsAuthenticated);
        }

        [TestMethod]
        public async Task WhenUserLoginInEmailRoamingSettingsShouldBeStored()
        {
            await auth.Login(EMAIL, PASSWORD);

            Assert.AreEqual(EMAIL, ApplicationData.Current.RoamingSettings.Values["email"]);
        }

        [TestMethod]
        public async Task WhenUserLoginInPasswordRoamingSettingsShouldBeStored()
        {
            await auth.Login(EMAIL, PASSWORD);

            Assert.AreEqual(PASSWORD, ApplicationData.Current.RoamingSettings.Values["password"]);
        }

        [TestMethod]
        public async Task WhenUserLogoutHeShouldBeAuthenticated()
        {
            auth.Logout();

            Assert.IsFalse(auth.IsAuthenticated);
        }
    }
}
