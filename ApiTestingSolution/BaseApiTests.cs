namespace Tests
{
    using ApiGateway;
    using ApiGateway.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Tests;

    public class BaseApiTests<T> : TestsSetUp
        where T : BaseApiService
    {
        protected readonly T _service =
            (T)Activator.CreateInstance(typeof(T), _serviceProvider.GetService<IApiClient>());

        public BaseApiTests()
        {
        }
    }
}