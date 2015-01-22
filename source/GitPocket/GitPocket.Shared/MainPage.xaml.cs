using System;
using GitPocket.ViewModel;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace GitPocket
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
#if WINDOWS_PHONE_APP
            var statusBar = StatusBar.GetForCurrentView();

            await statusBar.HideAsync();
#endif
            var mainViewModel = (MainViewModel)DataContext;

            mainViewModel.PropertyChanged += (o, p) =>
            {
                if (p.PropertyName == "State")
                {
                    var viewModel = (MainViewModel)o;
                    VisualStateManager.GoToState(this, viewModel.State, true);
                }
            };

        }
    }
}
