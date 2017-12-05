using System.Windows;

namespace DoogleMaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IMainWindowViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void Image_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            IMainWindowViewModel viewModel = (IMainWindowViewModel)DataContext;

            if (e.Delta > 0)
            {
                ++viewModel.Zoom;
            }
            else if (e.Delta < 0)
            {
                --viewModel.Zoom;
            }
        }
    }
}
