namespace Tests.Tests
{
    using ApiGateway;
    using ApiGateway.Models.Requests;
    using ApiGateway.Services;
    using HttpClient;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using NUnit.Framework;

    public class TestsSetUp
    {
        private static readonly string _baseUrl = "http://localhost:5000/";

        protected static readonly IServiceProvider _serviceProvider = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IApiClient>(new ApiHttpClient(_baseUrl));
            })
            .Build()
            .Services;

        [OneTimeSetUp]
        public async Task BeforeTestsRun()
        {
            IApiClient apiClient = _serviceProvider.GetService<IApiClient>();

            AuthenticationService authenticationService =
                new AuthenticationService(apiClient);

            string authToken = await authenticationService.GetAuthToken(
                "api/auth/login",
                new UserCredentialsRequest
                {
                    UserName = "user1",
                    Password = "user1password"
                });

            apiClient.AuthToken = authToken;
        }
    }
}