using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleMaps
{
    public class GoogleMapsApiService : IGoogleMapsApiService
    {
        private const string ApiKey = "AIzaSyCLJkhjT25UM_zeQDT0qC__vNX9dY40mm4";

        public async Task<Stream> GetViewportStreamAsync(int zoom)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/");
            string center = "Berkeley,CA";
            int width = 400;
            int height = 400;
            string requestUri = $"maps/api/staticmap?center={center}&zoom={zoom}&size={width}x{height}&key={ApiKey}";
            HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri);
            Stream imageStream = await responseMessage.Content.ReadAsStreamAsync();

            return imageStream;

        }
    }
}
