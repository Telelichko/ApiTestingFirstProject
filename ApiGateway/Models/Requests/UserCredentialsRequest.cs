namespace ApiGateway.Models.Requests
{
    using System.Text.Json.Serialization;

    public class UserCredentialsRequest : BaseModel
    {
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}