using System.Net;
using System.Text.Json;
using Week4.Interfaces;
using Week4.Utils;

namespace Week4.Services
{
    public class HttpRequest : IHttpRequest
    {

        #region Properties
        // we only need 1 instance of HttpClient
        private static readonly HttpClient HttpClient = new HttpClient();
        #endregion

        #region Helper methods

        protected void EnsureNetworkConnected()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                throw new ApplicationException("Please ensure that you have Internet connectivity and try again.");
        }

        protected HttpRequestMessage CreateRequestMessage(HttpMethod method, string url, HttpContent content = default)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = method,
                Content = content,
            };

            return request;
        }

        #endregion

        #region Get Task Async

        public async Task<T> GetTaskAsync<T>(string url, CancellationToken cancellation = default) where T : class
        {
            EnsureNetworkConnected();

            var request = CreateRequestMessage(HttpMethod.Get, url);
            var response = await HttpClient.SendAsync(request, cancellation);
            return await GetResponse<T>(response);
        }

        public async Task<Stream> GetStreamAsync(string url, CancellationToken cancellationToken = default)
        {
            EnsureNetworkConnected();

            var request = CreateRequestMessage(HttpMethod.Get, url);
            var response = await HttpClient.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // success
                return await response.Content.ReadAsStreamAsync();
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ThrowExceptionWithResponse(response, responseContent);
                return null;
            }
        }
        #endregion

        #region Post task Async

        public async Task PostTaskAsync(string url, object content, CancellationToken cancellation = default)
        {
            await PostTaskAsync<object>(url, content, cancellation);
        }

        public async Task<T> PostTaskAsync<T>(string url, object content, CancellationToken cancellation = default) where T : class
        {
            EnsureNetworkConnected();
            var bodyRequest = content.ObjectToStringContent();
            var request = CreateRequestMessage(HttpMethod.Post, url, bodyRequest);
            var response = await HttpClient.SendAsync(request, cancellation);
            return await GetResponse<T>(response);
        }

        #endregion

        #region Delete Task Async

        public async Task DeleteTaskAsync(string url, CancellationToken cancellation = default)
        {
            await DeleteTaskAsync<object>(url, cancellation);
        }

        public async Task<T> DeleteTaskAsync<T>(string url, CancellationToken cancellation = default) where T : class
        {
            EnsureNetworkConnected();

            var request = CreateRequestMessage(HttpMethod.Delete, url);
            var response = await HttpClient.SendAsync(request, cancellation);
            return await GetResponse<T>(response);
        }

        #endregion

        #region Put Task Async

        public async Task PutTaskAsync(string url, HttpContent content, CancellationToken cancellation = default)
        {
            await PutTaskAsync<object>(url, content, cancellation);
        }

        public async Task<T> PutTaskAsync<T>(string url, HttpContent content, CancellationToken cancellation = default) where T : class
        {
            EnsureNetworkConnected();

            var request = CreateRequestMessage(HttpMethod.Put, url, content);

            var response = await HttpClient.SendAsync(request, cancellation);
            return await GetResponse<T>(response);
        }

        #endregion

        #region GetResponse

        private async Task<T> GetResponse<T>(HttpResponseMessage response)
        {

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // success
                return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                }); // JsonConvert.DeserializeObject<T>(responseContent);
            }
            else
            {
                ThrowExceptionWithResponse(response, responseContent);
                return default;
            }
        }

        private void ThrowExceptionWithResponse(HttpResponseMessage response, string responseContent)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException(response.ReasonPhrase);
            }
            else
            {
                // look for any readable user error message
                // caller should catch ApplicationException and display error message
                if (string.CompareOrdinal(response.Content.Headers.ContentType?.MediaType, "application/json") == 0)
                {
                    var errorDict = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent);

                    if (errorDict.TryGetValue("error", out string errorMesg)) throw new ApplicationException(errorMesg);
                    if (errorDict.TryGetValue("error_description", out errorMesg)) throw new ApplicationException(errorMesg);
                    if (errorDict.TryGetValue("description", out errorMesg)) throw new ApplicationException(errorMesg);
                }
            }

            // if we get here, there is nothing readable so throw generic exception
            throw new Exception(response.ReasonPhrase, new Exception(responseContent));
        }

        #endregion

    }


}
