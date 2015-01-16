using GalaSoft.MvvmLight;
using GitPocket.IoC;
using Microsoft.Practices.ServiceLocation;

namespace GitPocket.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => NinjectServiceLocator.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                //SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                // Create run time view services and models
                //SimpleIoc.Default.Register<IDataService, DataService>();
            }

            NinjectServiceLocator.Default.Bind<MainViewModel>().ToSelf();
        }

        public static MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}