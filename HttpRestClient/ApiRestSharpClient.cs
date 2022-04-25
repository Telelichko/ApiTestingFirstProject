namespace RestSharpClient
{
    using ApiGateway;
    using ApiGateway.ApiClient;
    using RestSharp;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApiRestSharpClient : IApiClient
    {
        private readonly string _baseUrl;

        private readonly RestClient _restClient;

        private static string _authToken;

        public ApiRestSharpClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _restClient = new RestClient(_baseUrl);
        }

        public string AuthToken
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _authToken = $"Bearer {value}";
                }
            }
        }

        public async Task<IApiResponse<T>> SendGetRequestAsync<T>(string url, Dictionary<string, string>? headers = null)
            where T : class
        {
            var apiResponse = await SendExecuteRequest<T>(Method.Get, url, null, headers);
            return apiResponse;
        }

        public async Task<IApiResponse<T>> SendPostRequestAsync<T>(string url, object body, Dictionary<string, string>? headers = null)
            where T : class
        {
            var apiResponse = await SendExecuteRequest<T>(Method.Post, url, body, headers);
            return apiResponse;
        }

        public async Task<IApiResponse<T>> SendDeleteRequestAsync<T>(string url, Dictionary<string, string>? headers = null)
            where T : class
        {
            var apiResponse = await SendExecuteRequest<T>(Method.Delete, url, null, headers);
            return apiResponse;
        }

        public async Task<IApiResponse<T>> SendExecuteRequest<T>(Method requestMethod, string url, object body = null, Dictionary<string, string>? headers = null)
            where T : class
        {
            RestRequest restRequest = new RestRequest(url);

            SetHeaders(restRequest, headers);

            if (body is not null)
            {
                restRequest.AddBody(body);
            }

            RestResponse<T> restResponse = await _restClient.ExecuteAsync<T>(restRequest, requestMethod);

            var apiResponse = new ApiResponse<T>()
            { ResponseStatus = (int)restResponse.StatusCode, ResponseObject = restResponse.Data };

            return apiResponse;
        }

        private void SetHeaders(RestRequest restRequest, Dictionary<string, string>? headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(_authToken))
            {
                headers.Add("Authorization", _authToken);
            }

            restRequest.AddHeaders(headers);
        }
    }
}