using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GoogleMaps
{
    public interface IGoogleMapsApiService
    {
        Task<Stream> GetViewportStreamAsync();
    }
}
