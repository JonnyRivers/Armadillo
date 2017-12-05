using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;

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

            IServiceProvider serviceProvider = BuildServiceProvider();
            Window mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private IServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            // Framework services
            ILoggerFactory loggerFactory = new LoggerFactory().AddDebug();
            serviceCollection.AddSingleton(loggerFactory);
            serviceCollection.AddLogging();

            // Application services
            serviceCollection.AddTransient<IGoogleMapsApiService, GoogleMapsApiService>();

            // View models
            serviceCollection.AddTransient<IMainWindowViewModel, MainWindowViewModel>();

            // Views
            serviceCollection.AddTransient<MainWindow>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
