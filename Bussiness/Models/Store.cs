using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class Store
    {
        public int Id { get; set; }
        public required string Surcursal { get; set; }
        public required string Addres { get; set; }

        public IEnumerable<ProductStore> Products { get; set; } = new List<ProductStore>();
    }
}
