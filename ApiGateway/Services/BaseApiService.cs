namespace ApiGateway.Services
{
    public class BaseApiService
    {
        protected readonly IApiClient _apiClient;

        public BaseApiService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}