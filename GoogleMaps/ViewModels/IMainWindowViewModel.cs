using System.Windows.Media;

namespace GoogleMaps
{
    public interface IMainWindowViewModel
    {
        ImageSource ViewportImageSource { get; set; }
        int Zoom { get; set; }
    }
}
