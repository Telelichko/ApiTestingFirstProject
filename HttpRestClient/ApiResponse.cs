namespace RestSharpClient
{
    using ApiGateway.ApiClient;

    public class ApiResponse<T> : IApiResponse<T>
    {
        public int ResponseStatus
        {
            get; set;
        }

        public T ResponseObject
        {
            get; set;
        }
    }
}