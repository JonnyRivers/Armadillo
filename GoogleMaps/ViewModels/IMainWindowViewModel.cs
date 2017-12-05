using System.Windows.Media;

namespace GoogleMaps
{
    public interface IMainWindowViewModel
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
        int Zoom { get; set; }
        ImageSource ViewportImageSource { get; set; }
        
    }
}
