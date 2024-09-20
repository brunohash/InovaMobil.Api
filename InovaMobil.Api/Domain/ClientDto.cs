using System.Text.Json.Serialization;

namespace InovaMobil.Api.Domain
{
    public class ClientDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Uuid { get; set; } = Guid.NewGuid().ToString("N");
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? DocumentType { get; set; }
        public string? Document { get; set; }
        public int? AreaCode { get; set; }
        public int? Number { get; set; }
        public int? Status { get; set; } = 1;
    }
}

