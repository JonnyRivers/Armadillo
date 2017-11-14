using System.IO;
using System.Threading.Tasks;

namespace GoogleMaps
{
    public interface IGoogleMapsApiService
    {
        Task<Stream> GetViewportStreamAsync(int zoom);
    }
}
