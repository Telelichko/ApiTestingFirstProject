namespace ApiGateway.Models.Responses
{
    using System;
    using System.Text.Json.Serialization;

    public class ProfessorDeleteResponse : BaseModel
    {
        [JsonPropertyName("deletedId")]
        public Guid DeletedId { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}