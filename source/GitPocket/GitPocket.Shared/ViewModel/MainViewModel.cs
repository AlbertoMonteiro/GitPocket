using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GitPocket.Business;
using PropertyChanged;

namespace GitPocket.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuthentication authentication;

        public MainViewModel(IAuthentication authentication)
        {
            this.authentication = authentication;
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                UserName = "email@email.com";
                Name = "FirstName LastName";
                Login = "MyLogin";
            } else
                UserName = "empty";

            OnLogin = new RelayCommand(() => DoLogin());
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Organization { get; set; }

        public string Email { get; set; }

        public string Site { get; set; }

        public int Followers { get; set; }

        public string Starred { get; set; }

        public int Following { get; set; }

        public string State { get; set; }

        public ImageSource Avatar { get; set; }

        public RelayCommand OnLogin { get; set; }

        private async Task DoLogin()
        {
            var gitHubClient = await authentication.Login(UserName, Password);
            var user = await gitHubClient.User.Current();
            Name = user.Name;
            Login = user.Login;
            Email = user.Email;
            Organization = user.Company;
            Site = user.Blog;
            Followers = user.Followers;
            Following = user.Following;
            State = "LoggedIn";
            Avatar = new BitmapImage(new Uri(user.AvatarUrl));
        }
    }
}
