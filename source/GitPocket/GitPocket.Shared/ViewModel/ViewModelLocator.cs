using GalaSoft.MvvmLight;
using GitPocket.Business;
using GitPocket.IoC;
using Microsoft.Practices.ServiceLocation;
using Octokit;

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
            NinjectServiceLocator.Default.Bind<IAuthentication>().To<Authentication>();
            NinjectServiceLocator.Default.Bind<ProductHeaderValue>().ToConstant(new ProductHeaderValue("GitPocket"));
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