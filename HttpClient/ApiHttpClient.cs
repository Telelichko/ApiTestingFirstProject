namespace HttpClient
{
    using ApiGateway;
    using ApiGateway.ApiClient;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;

    public class ApiHttpClient : IApiClient
    {
        private readonly string _baseUrl;

        private readonly HttpClient _httpClient;

        public ApiHttpClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public string AuthToken
        {
            set
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", value);
            }
        }

        public async Task<IApiResponse<T>> SendGetRequestAsync<T>(string url, Dictionary<string, string>? headers)
            where T : class
        {
            return await SendRestRequestAsync<T>(HttpMethod.Get, url, headers);
        }

        public async Task<IApiResponse<T>> SendPostRequestAsync<T>(string url, object body, Dictionary<string, string>? headers)
            where T : class
        {
            return await SendRestRequestAsync<T>(HttpMethod.Post, url, headers, body);
        }

        public async Task<IApiResponse<T>> SendDeleteRequestAsync<T>(string url, Dictionary<string, string>? headers)
            where T : class
        {
            return await SendRestRequestAsync<T>(HttpMethod.Delete, url, headers);
        }

        private async Task<IApiResponse<T>> SendRestRequestAsync<T>(HttpMethod httpMethod, string url, Dictionary<string, string>? headers, object? body = null)
            where T : class
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, url);

            SetHeaders(httpRequestMessage, headers);

            if (body != null)
            {
                httpRequestMessage.Content = new StringContent(
                    JsonSerializer.Serialize(body),
                    Encoding.UTF8,
                    "application/json");
            }

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            string responseBody = await response.Content.ReadAsStringAsync();

            T responseT = JsonSerializer.Deserialize<T>(responseBody);

            return new ApiResponse<T>() { ResponseStatus = (int)response.StatusCode, ResponseObject = responseT };
        }

        private void SetHeaders(HttpRequestMessage httpRequestMessage, Dictionary<string, string>? headers = null)
        {

            headers = headers ?? new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
        }
    }
}