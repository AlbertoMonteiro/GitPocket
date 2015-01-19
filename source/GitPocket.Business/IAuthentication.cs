namespace GitPocket.Business
{
    public interface IAuthentication
    {
        string Email { get; }

        string Password { get; }

        bool IsAuthenticated { get; }

        /// <summary>
        ///     Tries to authenticate and save the email/password in roaming settings storage
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        void Login(string email, string password);

        /// <summary>
        ///     Logout and clear the cache
        /// </summary>
        void Logout();
    }
}
