namespace ApiGateway.Models.Responses
{
    using System;
    using System.Text.Json.Serialization;

    public class ProfessorAddResponse : BaseModel
    {
        [JsonPropertyName("createdId")]
        public Guid CreatedId { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}