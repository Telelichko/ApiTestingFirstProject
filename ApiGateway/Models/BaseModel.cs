namespace ApiGateway.Models
{
    using System.Text.Json;

    public abstract class BaseModel
    {
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}