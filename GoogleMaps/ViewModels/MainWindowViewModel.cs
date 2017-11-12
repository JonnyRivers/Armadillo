using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Armadillo.ViewModels;
using System.Windows.Media.Imaging;

namespace GoogleMaps
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private IGoogleMapsApiService _googleMapsApiService;

        public MainWindowViewModel(IGoogleMapsApiService googleMapsApiService)
        {
            _googleMapsApiService = googleMapsApiService;

            Task.Factory.StartNew(LoadViewportAsync);
        }

        private async Task LoadViewportAsync()
        {
            Stream imageStream = await _googleMapsApiService.GetViewportStreamAsync();

            await App.Current.Dispatcher.BeginInvoke((Action)delegate () {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = imageStream;
                bitmapImage.EndInit();
                
                ViewportImageSource = bitmapImage;
            });
        }

        private ImageSource _viewportImageSource;

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
