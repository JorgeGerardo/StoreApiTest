using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Addres { get; set; }

        public IEnumerable<CustomerProduct> CartProducts { get; set; } = new List<CustomerProduct>();
    }
}
