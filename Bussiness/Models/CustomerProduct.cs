using System.Text.Json.Serialization;

namespace Bussiness.Models
{
    public class CustomerProduct :BaseModel
    {
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }

        public int ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }

        public required DateTime Date { get; set; }

        public required int Quantity { get; set; }

    }

}
