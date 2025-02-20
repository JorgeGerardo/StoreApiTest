using System.Text.Json.Serialization;

namespace Bussiness.Models
{
    public class Store : BaseModel
    {
        public required string Sucursal { get; set; }
        public required string Address { get; set; }

        [JsonIgnore]
        public IEnumerable<StoreInventary> Products { get; set; } = new List<StoreInventary>();
    }

    public class StoreCreateDto
    {
        public required string Sucursal { get; set; }
        public required string Address { get; set; }
    }

    public class StoreUpdateDto
    {
        public required int Id { get; set; }
        public required string Sucursal { get; set; }
        public required string Address { get; set; }
    }
}
