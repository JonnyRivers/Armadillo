using System.Net.Http;

namespace Armadillo.Services
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
        HttpClient CreateHttpClient(HttpClientHandler handler);
        HttpClient CreateHttpClient(HttpClientHandler handler, bool disposeHandler);
    }
}
