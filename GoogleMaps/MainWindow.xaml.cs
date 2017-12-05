using System.Windows;

namespace DoogleMaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMainWindowViewModel _viewModel;

        public MainWindow(IMainWindowViewModel viewModel)
        {
            InitializeComponent();

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
    }
}
