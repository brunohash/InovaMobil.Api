using System.Text.Json.Serialization;

namespace InovaMobil.Api.Domain
{
    public class ProductDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Uuid { get; set; } = Guid.NewGuid().ToString("N");
        public string? Name { get; set; }
        public string? Batery { get; set; }
        public string? Image { get; set; }
        public string? Status { get; set; }
    }
}

