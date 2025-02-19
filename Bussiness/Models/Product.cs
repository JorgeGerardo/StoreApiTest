﻿namespace Bussiness.Models
{
    public class Product : BaseModel
    {
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
        public int Stock { get; set; }


    }
}
