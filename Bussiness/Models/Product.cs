namespace Bussiness.Models
{
    public class Product : BaseModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
    }

    public class ProductCreateDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
    }

    public class ProductUpdateDTO : Product {
        public new int? Id { get; set; }
    }


    public class ProductCartItem : Product
    {
        public required int Quantity { get; set; }
    }
}
