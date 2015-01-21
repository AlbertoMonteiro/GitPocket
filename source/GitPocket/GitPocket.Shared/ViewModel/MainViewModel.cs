using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace GitPocket.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string password;
        private string userName;

        public MainViewModel()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
                UserName = "email@email.com";
            else
                UserName = "empty";

            OnLogin = new RelayCommand(Login);
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

        private void Login()
        {
            throw new NotImplementedException();
        }
    }
}
