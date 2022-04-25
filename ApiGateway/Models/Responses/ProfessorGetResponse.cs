namespace ApiGateway.Models.Responses
{
    using System;
    using System.Text.Json.Serialization;

    public class ProfessorGetResponse : BaseModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }
    }
}