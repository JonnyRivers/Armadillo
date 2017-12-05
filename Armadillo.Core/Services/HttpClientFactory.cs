using System.Net.Http;

namespace Armadillo.Services
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient()
        {
            return new HttpClient();
        }

        public HttpClient CreateHttpClient(HttpClientHandler handler)
        {
            return new HttpClient(handler);
        }

        public HttpClient CreateHttpClient(HttpClientHandler handler, bool disposeHandler)
        {
            return new HttpClient(handler, disposeHandler);
        }
    }
}
