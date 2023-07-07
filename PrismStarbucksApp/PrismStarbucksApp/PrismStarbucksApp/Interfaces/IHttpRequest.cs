using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PrismStarbucksApp.Interfaces;

public interface IHttpRequest
{
    Task PostTaskAsync(string url, object content, CancellationToken cancellation = default);
    Task<T> PostTaskAsync<T>(string url, object content, CancellationToken cancellation = default) where T : class;

    Task<T> GetTaskAsync<T>(string url, CancellationToken cancellation = default) where T : class;

    Task<Stream> GetStreamAsync(string url, CancellationToken cancellationToken = default);

    Task DeleteTaskAsync(string url, CancellationToken cancellation = default);
    Task<T> DeleteTaskAsync<T>(string url, CancellationToken cancellation = default) where T : class;
    Task PutTaskAsync(string url, HttpContent content, CancellationToken cancellation = default);

    Task<T> PutTaskAsync<T>(string url, HttpContent content, CancellationToken cancellation = default) where T : class;

}
