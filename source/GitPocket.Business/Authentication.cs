using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace GitPocket.Business
{
    class Authentication
    {
        private bool _isAuthenticated;
        ApplicationDataContainer roamingSettings;
        
        public Authentication()
        {
            roamingSettings = ApplicationData.Current.RoamingSettings; // how we should store the login data
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                _isAuthenticated = value;
            }
        }

        /// <summary>
        /// Tries to authenticate and save the email/password in roaming settings storage
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void Login(string email, string password)
        {
            Email = email;
            Password = password;

            // Log the user in then store the login data if successful

            roamingSettings.Values["email"] = email;
            roamingSettings.Values["password"] = password;

            IsAuthenticated = true;
        }

        /// <summary>
        /// Logout and clear the cache
        /// </summary>
        public void Logout()
        {
            roamingSettings.Values.Remove("email");
            roamingSettings.Values.Remove("password");

            IsAuthenticated = false;
        }
    }
}
