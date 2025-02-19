namespace Bussiness.Models
{
    public class Store : BaseModel
    {
        public required string Surcursal { get; set; }
        public required string Address { get; set; }

        public IEnumerable<ProductStore> Products { get; set; } = new List<ProductStore>();
    }
}
