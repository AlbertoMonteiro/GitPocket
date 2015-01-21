using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GitPocket.Business;

namespace GitPocket.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuthentication authentication;
        private string password;
        private string userName;

        public MainViewModel(IAuthentication authentication)
        {
            this.authentication = authentication;
            if (IsInDesignMode || IsInDesignModeStatic)
                UserName = "email@email.com";
            else
                UserName = "empty";

            OnLogin = new RelayCommand(() => Login());
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

        public RelayCommand OnLogin { get; set; }

        private async Task Login()
        {
            var gitHubClient = await authentication.Login(UserName, Password);
            var user = await gitHubClient.User.Current();
            UserName = user.Name;
        }
    }
}
