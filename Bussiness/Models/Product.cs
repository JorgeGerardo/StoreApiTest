using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class Product
    {
        public int Id { get; set; } //Codigo
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
        public int Stock { get; set; }


    }
}
