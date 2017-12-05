using Armadillo.Services;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DoogleMaps
{
    public class GoogleMapsApiService : IGoogleMapsApiService
    {
        private const string ApiKey = "AIzaSyCLJkhjT25UM_zeQDT0qC__vNX9dY40mm4";

        private readonly ILogger<GoogleMapsApiService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public GoogleMapsApiService(ILogger<GoogleMapsApiService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Stream> GetViewportStreamAsync(double latitude, double longitude, int width, int height, int zoom)
        {
            var httpClient = _httpClientFactory.CreateHttpClient();
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/");
            
            string requestUri = $"maps/api/staticmap?center={latitude},{longitude}&zoom={zoom}&size={width}x{height}&key={ApiKey}";
            _logger.LogDebug($"sending reuest '{requestUri}'");
            HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri);
            Stream imageStream = await responseMessage.Content.ReadAsStreamAsync();

            return imageStream;

        }
    }
}
