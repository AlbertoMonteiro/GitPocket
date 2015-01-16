using GalaSoft.MvvmLight;

namespace GitPocket.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        string userName;

        public MainViewModel()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                UserName = "email@email.com";
            }
            else
            {
                UserName = "empty";                
            }
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
    }
}
