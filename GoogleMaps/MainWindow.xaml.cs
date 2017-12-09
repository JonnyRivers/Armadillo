using Microsoft.Extensions.Logging;
using System.Windows;

namespace DoogleMaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILogger<MainWindow> _logger;
        private IMainWindowViewModel _viewModel;
        private Point _mouseDownPosition;

        public MainWindow(ILogger<MainWindow> logger, IMainWindowViewModel viewModel)
        {
            InitializeComponent();

            _logger = logger;
            _viewModel = viewModel;

            DataContext = viewModel;
        }

        private void OnViewportMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                _viewModel.ZoomInCommand.Execute(null);
            }
            else if (e.Delta < 0)
            {
                _viewModel.ZoomOutCommand.Execute(null);
            }
        }

        private void OnViewportMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(null);
            _logger.LogInformation($"Image_MouseUp @ {position.X},{position.Y}");

            Vector movement = _mouseDownPosition - position;
            _logger.LogInformation($"Image_MouseUp movement - {movement.X},{movement.Y}");

            _viewModel.ViewportScrollCommand.Execute(movement);
        }

        private void OnViewportMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _mouseDownPosition = e.GetPosition(null);
            _logger.LogInformation($"Image_MouseDown @ {_mouseDownPosition.X},{_mouseDownPosition.Y}");
        }
    }
}
