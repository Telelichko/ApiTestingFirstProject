namespace ApiGateway.Models.Requests
{
    using System.Text.Json.Serialization;

    public class ProfessorAddRequest
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }
    }
}
