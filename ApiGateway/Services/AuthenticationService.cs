namespace ApiGateway.Services
{
    using Models.Requests;
    using Models.Responses;
    using System.Threading.Tasks;

    public class AuthenticationService : BaseApiService
    {
        protected readonly IApiClient _apiClient;

        public AuthenticationService(IApiClient apiClient) : base(apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<string> GetAuthToken(string endpoint, UserCredentialsRequest userCredentialsRequest)
        {
            var token = await _apiClient.SendPostRequestAsync<AuthTokenPostResponse>(endpoint, userCredentialsRequest);

            return token.ResponseObject.AccessToken;
        }
    }
}