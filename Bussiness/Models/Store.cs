﻿namespace Bussiness.Models
{
    public class Store : BaseModel
    {
        public required string Sucursal { get; set; }
        public required string Address { get; set; }

        public IEnumerable<ProductStore> Products { get; set; } = new List<ProductStore>();
    }

    public class StoreCreateDto
    {
        public required string Sucursal { get; set; }
        public required string Address { get; set; }
    }
}
