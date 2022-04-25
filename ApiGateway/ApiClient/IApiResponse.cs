namespace ApiGateway.ApiClient
{
    public interface IApiResponse<T>
    {
        int ResponseStatus { get; set; }

        T ResponseObject { get; set; }
    }
}