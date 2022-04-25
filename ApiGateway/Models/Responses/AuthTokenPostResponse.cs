namespace ApiGateway.Models.Responses
{
    using System.Text.Json.Serialization;

    public class AuthTokenPostResponse : BaseModel
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public DateTime ExpiresIn { get; set; }
    }
}