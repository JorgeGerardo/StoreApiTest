namespace Bussiness.Models
{
    public class CustomerProduct :BaseModel
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public required DateTime Date { get; set; }

    }

}
