using static Mysqlx.Expect.Open.Types;
using System.Text.Json.Serialization;

namespace InovaMobil.Api.Domain
{
    public class SalesDto
    {
        public string? Id_Client { get; set; }
        public string? Id_Product { get; set; }

        [JsonIgnore]
        public string? Reason { get; set; }
    }
}

