using System.Text.Json.Serialization;

namespace Bussiness.Models
{
    public class StoreInventary : BaseModel
    {
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }

        public int StoreId { get; set; }
        [JsonIgnore]
        public Store? Store { get; set; }

        public required int Stock { get; set; }

        [JsonIgnore]
        public IEnumerable<InventaryTransaction> Transacctions { get; set; } = new List<InventaryTransaction>();
    }

    public class StoreInventaryCreateDTO
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public required int Stock { get; set; }
    }

    public class StoreInventaryUpdateDTO : BaseModel
    {
        public required int ProductId { get; set; }
        public required int StoreId { get; set; }
        public required int Stock { get; set; }
    }

    public class StoreInventaryView
    {
        public required string Title { get; set; }
        public required string Image { get; set; }
        public required int ProductId { get; set; }
        public required int StoreId { get; set; }
        public required int Stock { get; set; }
    }

}
