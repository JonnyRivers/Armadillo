using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace DoogleMaps
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // TODO: Use DI as this grows
            var googleMapsApiService = new GoogleMapsApiService();
            var mainWindowViewModel = new MainWindowViewModel(googleMapsApiService);
            var mainWindow = new MainWindow(mainWindowViewModel);

            mainWindow.Show();
        }
    }
}
