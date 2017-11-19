using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SayIt.ApplicationServices;
using SayIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SayIt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();

            // Framework services
            serviceCollection.AddLogging();

            // Application services
            serviceCollection.AddTransient<ISpeechSynthesisService, SpeechSynthesisService>();

            // View models
            serviceCollection.AddTransient<IMainWindowViewModel, MainWindowViewModel>();

            // Views
            serviceCollection.AddTransient<MainWindow>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            Window mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
