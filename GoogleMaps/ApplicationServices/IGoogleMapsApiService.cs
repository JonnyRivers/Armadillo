using System.IO;
using System.Threading.Tasks;

namespace GoogleMaps
{
    public interface IGoogleMapsApiService
    {
        Task<Stream> GetViewportStreamAsync(double latitude, double longitude, int width, int height, int zoom);
    }
}
