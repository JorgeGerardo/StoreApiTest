namespace Bussiness.Models
{
    public class Customer : BaseModel
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }

        public IEnumerable<CustomerProduct> CartProducts { get; set; } = new List<CustomerProduct>();
    }

    public class CustomerCreateDTO
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
    }

    public class CustomerUpdateDTO
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
    }
}
