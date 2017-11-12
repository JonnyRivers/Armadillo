using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GoogleMaps
{
    // https://maps.googleapis.com/maps/api/staticmap?center=Berkeley,CA&zoom=14&size=400x400&key=AIzaSyCLJkhjT25UM_zeQDT0qC__vNX9dY40mm4

    public class GoogleMapsApiService : IGoogleMapsApiService
    {
        public async Task<Stream> GetViewportStreamAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://maps.googleapis.com/");
                HttpResponseMessage responseMessage = await httpClient.GetAsync("maps/api/staticmap?center=Berkeley,CA&zoom=14&size=400x400&key=AIzaSyCLJkhjT25UM_zeQDT0qC__vNX9dY40mm4");
                Stream imageStream = await responseMessage.Content.ReadAsStreamAsync();

                return imageStream;
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
