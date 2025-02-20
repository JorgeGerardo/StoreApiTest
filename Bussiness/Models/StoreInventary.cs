namespace Bussiness.Models
{
    public class StoreInventary : BaseModel
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }

        public required int Stock { get; set; }

        public IEnumerable<InventaryTransaction> Transacctions { get; set; } = new List<InventaryTransaction>();
    }

    public class StoreInventaryCreateDTO
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int StoreId { get; set; }
        public Store? Store { get; set; }
        public required int Stock { get; set; }
    }

    public class StoreInventaryUpdateDTO : BaseModel
    {
        public required int ProductId { get; set; }
        public Product? Product { get; set; }

        public required int StoreId { get; set; }
        public Store? Store { get; set; }

        public required int Stock { get; set; }


    }
}
