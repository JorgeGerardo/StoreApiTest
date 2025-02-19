namespace Bussiness.Models
{
    public class Customer : BaseModel
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Addres { get; set; }

        public IEnumerable<CustomerProduct> CartProducts { get; set; } = new List<CustomerProduct>();
    }
}
