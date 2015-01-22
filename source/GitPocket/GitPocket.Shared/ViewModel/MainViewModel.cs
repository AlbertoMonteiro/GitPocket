using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Xaml.Media;
using GitPocket.Business;

namespace GitPocket.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        readonly IAuthentication authentication;
        string email;
        int followers;
        int following;
        string login;
        string name;
        string organization;
        string password;
        string site;
        string starred;
        string userName;

        public MainViewModel(IAuthentication authentication)
        {
            this.authentication = authentication;
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                UserName = "email@email.com";
                Name = "FirstName LastName";
                Login = "MyLogin";

            }
            else
                UserName = "empty";

            OnLogin = new RelayCommand(() => DoLogin());
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                RaisePropertyChanged();
            }
        }

        public string Organization
        {
            get { return organization; }
            set
            {
                organization = value;
                RaisePropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged();
            }
        }

        public string Site
        {
            get { return site; }
            set
            {
                site = value;
                RaisePropertyChanged();
            }
        }

        public int Followers
        {
            get { return followers; }
            set
            {
                followers = value;
                RaisePropertyChanged();
            }
        }

        public string Starred
        {
            get { return starred; }
            set
            {
                starred = value;
                RaisePropertyChanged();
            }
        }

        public int Following
        {
            get { return following; }
            set
            {
                following = value;
                RaisePropertyChanged();
            }
        }

        private string state;
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                RaisePropertyChanged();
            }
        }

        private ImageSource avatar;
        public ImageSource Avatar
        {
            get { return avatar; }
            set
            {
                avatar = value;
                RaisePropertyChanged();
            }
        }



        public RelayCommand OnLogin { get; set; }

        async Task DoLogin()
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