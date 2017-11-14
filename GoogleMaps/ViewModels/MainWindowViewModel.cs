using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using Armadillo.ViewModels;
using System.Windows.Media.Imaging;

namespace GoogleMaps
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private IGoogleMapsApiService _googleMapsApiService;

        private ImageSource _viewportImageSource;
        private int _zoom;

        public MainWindowViewModel(IGoogleMapsApiService googleMapsApiService)
        {
            _googleMapsApiService = googleMapsApiService;
            _zoom = 14;

            RefreshViewport();
        }

        private async Task RefreshViewportAsync()
        {
            Stream imageStream = await _googleMapsApiService.GetViewportStreamAsync(_zoom);

            await App.Current.Dispatcher.BeginInvoke((Action)delegate () {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = imageStream;
                bitmapImage.EndInit();

                ViewportImageSource = bitmapImage;
            });
        }

        private void RefreshViewport()
        {
            Task.Factory.StartNew(RefreshViewportAsync);
        }

        public ImageSource ViewportImageSource
        {
            get => _viewportImageSource;
            set
            {
                if (_viewportImageSource != value)
                {
                    _viewportImageSource = value;

                    OnPropertyChanged();
                }
            }
        }

        public int Zoom
        {
            get => _zoom;
            set
            {
                if (_zoom != value)
                {
                    _zoom = value;

                    OnPropertyChanged();
                    RefreshViewport();
                }
            }
        }
    }
}
