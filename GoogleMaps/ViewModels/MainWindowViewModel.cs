using Armadillo.Commands;
using Armadillo.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows;

namespace DoogleMaps
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private const double DefaultLatitude = 51;
        private const double DefaultLongitude = 0;
        private const int MinimumZoom = 0;
        private const int DefaultZoom = 10;
        private const int MaximumZoom = 18;
        private const int DefaultWidth = 512;
        private const int DefaultHeight = 512;

        private IGoogleMapsApiService _googleMapsApiService;

        private double _latitude;
        private double _longitude;
        private int _zoom;
        private ImageSource _viewportImageSource;

        private ICommand _viewportScrollCommand;
        private ICommand _zoomInCommand;
        private ICommand _zoomOutCommand;

        public MainWindowViewModel(IGoogleMapsApiService googleMapsApiService)
        {
            _googleMapsApiService = googleMapsApiService;

            _latitude = DefaultLatitude;
            _longitude = DefaultLongitude;
            _zoom = DefaultZoom;

            _viewportScrollCommand = new RelayCommand(ViewportScrollExecute);
            _zoomInCommand = new RelayCommand(ZoomInExecute, ZoomInCanExecute);
            _zoomOutCommand = new RelayCommand(ZoomOutExecute, ZoomOutCanExecute);

            RefreshViewport();
        }

        private async Task RefreshViewportAsync()
        {
            Stream imageStream = await _googleMapsApiService.GetViewportStreamAsync(_latitude, _longitude, DefaultWidth, DefaultHeight, _zoom);

            await App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
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

        public ICommand ViewportScrollCommand => _viewportScrollCommand;

        public ICommand ZoomInCommand => _zoomInCommand;

        public ICommand ZoomOutCommand => _zoomOutCommand;

        private void ViewportScrollExecute(object obj)
        {
            Vector movement = (Vector)obj;

            double numTiles = Math.Pow(2, _zoom);
            double numPixels = numTiles * 256;

            double pixelsPerLatitude = numPixels / 180;
            double pixelsPerLongitude = numPixels / 360;

            double latitudeDelta = movement.Y / pixelsPerLatitude;
            double longitudeDelta = movement.X / pixelsPerLongitude;

            // Silently set these properties to prevent a double update
            _latitude -= latitudeDelta;
            _longitude += longitudeDelta;

            OnPropertyChanged(nameof(Latitude));
            OnPropertyChanged(nameof(Longitude));

            RefreshViewport();
        }

        private void ZoomInExecute(object obj)
        {
            ++Zoom;
        }

        private bool ZoomInCanExecute(object obj)
        {
            return Zoom < MaximumZoom;
        }

        private void ZoomOutExecute(object obj)
        {
            --Zoom;
        }

        private bool ZoomOutCanExecute(object obj)
        {
            return Zoom > MinimumZoom;
        }
    }
}
