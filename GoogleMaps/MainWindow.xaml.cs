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

        private void Image_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                ++_viewModel.Zoom;
            }
            else if (e.Delta < 0)
            {
                --_viewModel.Zoom;
            }
        }

        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(null);
            _logger.LogInformation($"Image_MouseUp @ {position.X},{position.Y}");

            Vector movement = _mouseDownPosition - position;
            _logger.LogInformation($"Image_MouseUp movement - {movement.X},{movement.Y}");

            double numTiles = System.Math.Pow(2, _viewModel.Zoom);
            double numPixels = numTiles * 256;

            double pixelsPerLatitude = numPixels / 180;
            double pixelsPerLongitude = numPixels / 360;

            double latitudeDelta = movement.Y / pixelsPerLatitude;
            double longitudeDelta = movement.X / pixelsPerLongitude;

            _viewModel.Latitude -= latitudeDelta;
            _viewModel.Longitude += longitudeDelta;
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _mouseDownPosition = e.GetPosition(null);
            _logger.LogInformation($"Image_MouseDown @ {_mouseDownPosition.X},{_mouseDownPosition.Y}");
        }
    }
}
