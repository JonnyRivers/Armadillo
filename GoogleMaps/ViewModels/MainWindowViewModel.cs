using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using Armadillo.ViewModels;
using System.Windows.Media.Imaging;

namespace DoogleMaps
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private IGoogleMapsApiService _googleMapsApiService;

        private const double DefaultLatitude = 51;
        private const double DefaultLongitude = 0;
        private const int DefaultZoom = 10;
        private const int DefaultWidth = 512;
        private const int DefaultHeight = 512;

        private double _latitude;
        private double _longitude;
        private int _zoom;
        private ImageSource _viewportImageSource;
        

        public MainWindowViewModel(IGoogleMapsApiService googleMapsApiService)
        {
            _googleMapsApiService = googleMapsApiService;

            _latitude = DefaultLatitude;
            _longitude = DefaultLongitude;
            _zoom = DefaultZoom;

            RefreshViewport();
        }

        private async Task RefreshViewportAsync()
        {
            Stream imageStream = await _googleMapsApiService.GetViewportStreamAsync(_latitude, _longitude, DefaultWidth, DefaultHeight, _zoom);

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

        public double Latitude
        {
            get => _latitude;
            set
            {
                if (_latitude != value)
                {
                    _latitude = value;

                    OnPropertyChanged();
                    RefreshViewport();
                }
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                if (_longitude != value)
                {
                    _longitude = value;

                    OnPropertyChanged();
                    RefreshViewport();
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
    }
}
