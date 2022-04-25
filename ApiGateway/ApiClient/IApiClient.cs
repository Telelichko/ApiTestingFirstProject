namespace ApiGateway;

using ApiClient;

public interface IApiClient
{
    public string AuthToken { set; }

    Task<IApiResponse<T>> SendGetRequestAsync<T>(string url, Dictionary<string, string>? headers = null)
        where T : class;

    Task<IApiResponse<T>> SendPostRequestAsync<T>(string url, object body, Dictionary<string, string>? headers = null)
        where T : class;

    Task<IApiResponse<T>> SendDeleteRequestAsync<T>(string url, Dictionary<string, string>? headers = null)
        where T : class;
}