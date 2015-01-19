using Windows.Storage;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GitPocket.Business.Test
{
    [TestClass]
    public class AuthenticationTest
    {
        private const string EMAIL = "mail@mail.com";
        private const string PASSWORD = "123456";

        [TestMethod]
        public void WhenUserLoginInHeShouldBeAuthenticated()
        {
            var auth = new Authentication();

            auth.Login(EMAIL, PASSWORD);

            Assert.IsTrue(auth.IsAuthenticated);
        }

        [TestMethod]
        public void WhenUserLoginInEmailRoamingSettingsShouldBeStored()
        {
            var auth = new Authentication();

            auth.Login(EMAIL, PASSWORD);

            Assert.AreEqual(EMAIL, ApplicationData.Current.RoamingSettings.Values["email"]);
        }

        [TestMethod]
        public void WhenUserLoginInPasswordRoamingSettingsShouldBeStored()
        {
            var auth = new Authentication();

            auth.Login(EMAIL, PASSWORD);

            Assert.AreEqual(PASSWORD, ApplicationData.Current.RoamingSettings.Values["password"]);
        }

        [TestMethod]
        public void WhenUserLogoutHeShouldBeAuthenticated()
        {
            var auth = new Authentication();

            auth.Logout();

            Assert.IsFalse(auth.IsAuthenticated);
        }
    }
}
